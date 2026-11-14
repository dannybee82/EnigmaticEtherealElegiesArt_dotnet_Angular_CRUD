import { Component, effect, inject, model, ModelSignal, OnDestroy, OnInit, signal, WritableSignal } from '@angular/core';
import { PaginatedData, PaginatedList } from '../../core/models/paginated-list/paginated-list.interface';
import { Artwork } from '../../core/models/art/artwork.interface';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { GenericsAllPagedListService } from '../../core/services/generics/all-paged-list/generics-all-paged-list';
import { RouterModule } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CustomPagination } from '../../core/components/custom-pagination/custom-pagination';
import { PaginationStoreSimple } from '../../core/services/pagination/pagination-store-simple';
import { defaultPagination } from '../../core/shared/shared-default-pagination.constants';

// Material modules.
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Loading } from '../../core/services/loading/loading';
import { ToastService } from '../../core/services/toast/toast-service';

@Component({
  imports: [MatCardModule, MatButtonModule, MatIconModule, MatTooltipModule, RouterModule, CustomPagination],
  selector: 'app-all-artworks',
  styleUrl: './all-artworks.scss',
  templateUrl: './all-artworks.html',
  providers: [
    GenericsAllPagedListService<PaginatedList<Artwork>>, 
    {
      provide: RESOURCE_CONFIG,
      useValue: {
        methodGetAllPagedList: { controller: 'Artwork', method: 'GetPagedList' }
      }
    }
  ],
})
export class AllArtworks implements OnInit, OnDestroy {

  protected artWorks: WritableSignal<PaginatedList<Artwork> | undefined> = signal<PaginatedList<Artwork> | undefined>(undefined);;
  private readonly _apiurl = environment.apiUrl;

  private readonly getAllPagedListService = inject(GenericsAllPagedListService<PaginatedList<Artwork>>);
  private paginationStoreSimple = inject(PaginationStoreSimple);  
  private loading = inject(Loading);
  protected paginationData: ModelSignal<PaginatedData> = model(this.paginationStoreSimple.simplePaginationStore() || defaultPagination);
  private toast = inject(ToastService);

  constructor() {
    effect(() => {
      if(this.getAllPagedListService.error()) {
        this.toast.show('Can\'t fetch all Artworks', 'error');
      }
    });

    effect(() => {
      this.loading.isLoading.set(this.getAllPagedListService.isLoading());
    });

    effect(() => {
      if(this.getAllPagedListService.data()) {
        this.artWorks.set(this.getAllPagedListService.data());        
        this.paginationData.set(
          Object.assign(this.getAllPagedListService.data() as PaginatedList<Artwork>)
        );
      }      
    });
  }

  ngOnInit(): void {    
    this.paginationData.set(this.paginationStoreSimple.simplePaginationStore() ?? defaultPagination);

    if(!this.artWorks()) {      
      // No Artworks loaded at this point.
      this.loadArtworks(this.paginationData());
    }
  }

  ngOnDestroy(): void {
    this.paginationStoreSimple.simplePaginationStore.set(this.paginationData());
  }

  getImageUrl(id: number | undefined): string {    
    return id ? `${this._apiurl}/Artwork/${id}` : '';
  }

  updatePagination($event: PaginatedData): void {
    const value: PaginatedData = this.paginationData();
    value.currentPage = $event.currentPage;
    value.pageSize = $event.pageSize;
    this.paginationData.set(value);
    this.loadArtworks(this.paginationData());
    this.getAllPagedListService.reload();
  }

  private loadArtworks(paginationData: PaginatedData): void {
    const params: Map<string, any> = new Map<string, any>([
      ['pageNumber', paginationData.currentPage],
      ['pageSize', paginationData.pageSize]      
    ]);
    this.getAllPagedListService.params.set(params);    
  }

}

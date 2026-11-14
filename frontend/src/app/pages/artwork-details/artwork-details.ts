import { Component, effect, inject, input, InputSignal, OnInit, Signal, signal, viewChild, WritableSignal } from '@angular/core';
import { Artwork } from '../../core/models/art/artwork.interface';
import { environment } from '../../../environments/environment';
import { YearsOfLifePipe } from '../../core/pipes/years-of-life.pipe';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { GenericsByIdService } from '../../core/services/generics/by_id/generics-by-id';
import { BackToMainComponent } from '../../core/components/back-to-main/back-to-main.component';
import { ToastService } from '../../core/services/toast/toast-service';

// Angular Material modules.
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Loading } from '../../core/services/loading/loading';

@Component({
  imports: [YearsOfLifePipe, MatButtonModule, MatIconModule, MatAccordion, MatExpansionModule, MatTooltipModule, BackToMainComponent],
  selector: 'app-artwork-details',
  styleUrl: './artwork-details.scss',
  templateUrl: './artwork-details.html',
  providers: [
    GenericsByIdService<Artwork>,
    {
      provide: RESOURCE_CONFIG,
      useValue: {        
        methodById: { controller: 'Artwork', method: 'GetById' }
      }
    }
  ]
})
export class ArtworkDetails implements OnInit {

  readonly id: InputSignal<number> = input.required<number>();
  readonly accordion: Signal<MatAccordion | undefined> = viewChild<MatAccordion | undefined>(MatAccordion);

  artwork: WritableSignal<Artwork | undefined> = signal<Artwork | undefined>(undefined);
  isPanelCollapsed: WritableSignal<boolean> = signal(false);
  private readonly _apiurl = environment.apiUrl;
  
  private readonly getByIdService = inject(GenericsByIdService<Artwork>);
  private readonly toast = inject(ToastService);
  private loading = inject(Loading);
  
  constructor() {
    effect(() => {
      if(this.accordion()) {
        this.accordion()!.openAll();
      }
    });

    effect(() => {
      if(this.getByIdService.error()) {
        this.toast.show(`Error fetching Artwork`, 'error');
      }
    });

    effect(() => {
      this.loading.isLoading.set(this.getByIdService.isLoading());
    });

    effect(() => {
      if(this.getByIdService.data()) {
        this.artwork.set(this.getByIdService.data());
      }      
    });
  }

  ngOnInit(): void {
    const params: Map<string, any> = new Map<string, any>([
      ['id', this.id()]
    ]);
    this.getByIdService.params.set(params);
  }

  getImageUrl(id: number | undefined): string {    
    return id ? `${this._apiurl}/Artwork/${id}` : '';
  }

  togglePanel(): void {
    this.isPanelCollapsed.set(!this.isPanelCollapsed());
  }

}

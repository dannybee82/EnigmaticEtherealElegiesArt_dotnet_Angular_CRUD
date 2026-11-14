import { Component, effect, inject, input, InputSignal, OnInit, ResourceStatus, signal, WritableSignal } from '@angular/core';
import { GenericsAllService } from '../../core/services/generics/all/generics-all';
import { Artist } from '../../core/models/artist/artist.interface';
import { RESOURCE_CONFIG } from '../../core/services/generics/tokens/resource.config';
import { Artwork } from '../../core/models/art/artwork.interface';
import { GenericsByIdService } from '../../core/services/generics/by_id/generics-by-id';
import { GenericsCreateService } from '../../core/services/generics/create/generics-create';
import { GenericsUpdateService } from '../../core/services/generics/update/generics-update';
import { environment } from '../../../environments/environment';
import { CreateOrUpdateArtworkInterface } from '../../core/models/create-or-update-artwork/create-or-update-artwork.interface';
import { form, min, required, FormField } from '@angular/forms/signals';
import { OpenFile } from '../../core/components/open-file/open-file';
import { LoadFilesInBrowser } from '../../core/services/load-file-in-browser/load-file-in-browser';
import { BackToMainComponent } from '../../core/components/back-to-main/back-to-main.component';
import { GenericsDeleteService } from '../../core/services/generics/delete-by-id/generics-delete';
import { Loading } from '../../core/services/loading/loading';

// Angular Material Modules
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { ToastService } from '../../core/services/toast/toast-service';
import { Router } from '@angular/router';
import { Dialog } from '../../core/components/delete-dialog/dialog';
import { DialogInterface } from '../../core/models/dialogs/dialog.interface';
import { DialogType } from '../../core/models/dialogs/dialog-type.enum';

@Component({
  imports: [FormField, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, OpenFile, MatIconModule, BackToMainComponent, Dialog],
  selector: 'app-create-or-update-artwork',
  styleUrl: './create-or-update-artwork.scss',
  templateUrl: './create-or-update-artwork.html',
  providers: [
    GenericsAllService<Artist>, GenericsByIdService<Artwork>, GenericsCreateService<Artwork>, GenericsUpdateService<Artwork>, GenericsDeleteService,
    {
      provide: RESOURCE_CONFIG,
      useValue: {
        methodGetAll: { controller: 'Artist', method: 'GetAll' },
        methodById: { controller: 'Artwork', method: 'GetById' },
        methodCreate: { controller: 'Artwork', method: 'Create' },
        methodUpdate: { controller: 'Artwork', method: 'Update' },
        methodDeleteById: { controller: 'Artwork', method: 'Delete' }
      }
    }
  ],
})
export class CreateOrUpdateArtwork implements OnInit {

  protected readonly id: InputSignal<number | undefined> = input.required<number | undefined>();

  artists: WritableSignal<Artist[]> = signal<Artist[]>([]);
  private _apiurl: string = environment.apiUrl;
  private _artworkToUpdate: WritableSignal<Artwork | undefined> = signal(undefined);
  protected isUpdateMode: WritableSignal<boolean> = signal<boolean>(false);
  protected imagePreview: WritableSignal<string> = signal('');
  
  protected showDialog: WritableSignal<boolean> = signal(false);
  dialogData: DialogInterface = {
    dialogType: DialogType.WARNING,
    dialogTitle: 'Delete Artwork',
    dialogMessage: '',
    dialogCancellationText: 'Cancel',
    dialogConfirmationText: 'Delete',
    dialogConfirmationIcon: 'delete'
  };

  private _defaultData: CreateOrUpdateArtworkInterface = {
    id: undefined,
    name: '',
    description: '',
    artistId: 0
  };
  protected formModel: WritableSignal<CreateOrUpdateArtworkInterface> = signal<CreateOrUpdateArtworkInterface>(structuredClone(this._defaultData));
  protected form = form(this.formModel, (form) => {
    required(form.name, { message: 'Name for the Artwork is required' });
    required(form.description, { message: 'Description for the Artwork is required' });
    required(form.artistId, { message: 'Artist for the Artwork is required' });
    min(form.artistId, 1, { message: 'Artist for the Artwork is required' });
  });
  private _file: File | undefined = undefined;
  protected isSubmitting: WritableSignal<boolean> = signal<boolean>(false);

  private readonly getAllArtistsService = inject(GenericsAllService<Artist>);
  private readonly getByIdArtworkService = inject(GenericsByIdService<Artwork>);
  private readonly createArtworkService = inject(GenericsCreateService<Artwork>);
  private readonly updateArtworkService = inject(GenericsUpdateService<Artwork>);
  private readonly deleteArtworkService = inject(GenericsDeleteService);
  private readonly loadFilesInBrowser = inject(LoadFilesInBrowser);
  private readonly toast = inject(ToastService);
  private readonly router = inject(Router);
  private readonly loadingService = inject(Loading);

  constructor() {
    effect(() => {
      const allArtists = this.getAllArtistsService.data();
      this.artists.set(allArtists ? allArtists : []);
    });

    effect(() => {
      const artwork: Artwork = this.getByIdArtworkService.data();

      if(artwork) {
        this._artworkToUpdate.set(artwork);

        if(this.isUpdateMode()) {
          this.formModel.set({
            id: this._artworkToUpdate()?.id,
            name: this._artworkToUpdate()?.name ?? '',
            description: this._artworkToUpdate()?.description ?? '',
            artistId: this._artworkToUpdate()?.artist?.id ?? 0
          });
        }
      }
    });

    effect(() => {
      if(this.getByIdArtworkService.error()) {
        this.toast.show(`Error fetching artwork by ID: ${this.getByIdArtworkService.error()}`, 'error');
        this.loadingService.isLoading.set(false);
      }
    });

    effect(() => {
      this.loadingService.isLoading.set(this.getByIdArtworkService.isLoading());      
    });

    effect(() => {
      const resolved: ResourceStatus = 'resolved';
      const error: ResourceStatus = 'error';
      const updateFinished = this.updateArtworkService.status();
      const createFinished = this.createArtworkService.status();
      const deleteFinished = this.deleteArtworkService.status();

      const successMessage: number = updateFinished === resolved ? 0 : createFinished === resolved ? 1 :  deleteFinished === resolved ? 2 : -1;
      const errorMessage: number = updateFinished === error ? 0 : createFinished === error ? 1 :  deleteFinished === error ? 2 : -1;

      switch(successMessage) {
        case 0:
          this.toast.show('Artwork successfully updated', 'success');
          break;
        case 1:
          this.toast.show('Artwork successfully created', 'success');
          break;
        case 2:
          this.toast.show('Artwork successfully deleted', 'success');
          break;
      }

      switch(errorMessage) {
        case 0:
          this.toast.show('Can\'t update Artwork', 'error');
          break;
        case 1:
          this.toast.show('Can\'t create Artwork', 'error');
          break;
        case 2:
          this.toast.show('Can\'t delete Artwork', 'error');
          break;
      }

      if(updateFinished === resolved || createFinished === resolved || deleteFinished === resolved) {
        this.createArtworkService.entity.set(undefined);
        this.updateArtworkService.entity.set(undefined);
        this.deleteArtworkService.id.set(undefined);
        this.router.navigate(['']);
      }
    });
  }

  ngOnInit(): void {    
    this.loadById();
  }

  submit($event: SubmitEvent): void {
    $event.preventDefault();
    this.isSubmitting.set(true);
    
    if(!this.form().valid) {
      this.isSubmitting.set(false);
      this.toast.show(`Form is invalid.`, 'error');
      return;
    }

    if(!this._file && !this.isUpdateMode()) {
      this.toast.show(`There is no image added yet.`, 'error');
      this.isSubmitting.set(false);
      return;
    }

    const data: CreateOrUpdateArtworkInterface = this.form().value();

    if(this.isUpdateMode()) {
      this.updateArtworkService.isFormData.set(true);
      this.updateArtworkService.entity.set(this.getFormData(data, this._file));
    } else {
      this.createArtworkService.isFormData.set(true);
      this.createArtworkService.entity.set(this.getFormData(data, this._file));
    }
  }

  getImageSource(): string {
    if(this.isUpdateMode()) {
      if(this._artworkToUpdate()?.imageId) {
        return `${this._apiurl}/Artwork/${this._artworkToUpdate()!.imageId}`;
      }      
    } 

    return this.imagePreview() !== '' ? this.imagePreview() : '';
  }

  getImageUrl(): string {    
    return this._artworkToUpdate()?.imageId ? `${this._apiurl}/Artwork/${this._artworkToUpdate()?.imageId}` : '';
  }

  removeFile(): void {
    this._file = undefined;
    this.imagePreview.set('');

    if(this.isUpdateMode() && this._artworkToUpdate()) {
      this._artworkToUpdate()!.imageId = undefined;
    }
  }

  loadFile($event: File): void {
    this._file = $event;

    this.loadFilesInBrowser.readFile($event).then((result: string | null) => {
      if (result) {
        if (
          this.loadFilesInBrowser.isValidDataType(result) &&
          this.loadFilesInBrowser.checkMaximumSize($event.size)
        ) {
          this.imagePreview.set(result);
        } else {
          if (!this.loadFilesInBrowser.isValidDataType(result)) {
            this.toast.show('File is invalid', 'error');
          } else if (this.loadFilesInBrowser.checkMaximumSize($event.size)) {
           this.toast.show('File exceeds 10 MB', 'error');
          }
        }
      } else {
        this.toast.show('Invalid file', 'error');
      }
    });
  }

  delete(): void {
    if(this.isUpdateMode()) {
      this.dialogData.dialogMessage = 'Do you really want to the delete the Artwork here below?';
      this.dialogData.dialogAdditionalText = `${this._artworkToUpdate()!.name} - ${this._artworkToUpdate()!.artist?.name}`,
      this.showDialog.set(true);
    }
  }

  execDelete($event: boolean): void {
    this.dialogData.dialogMessage = '';
    this.dialogData.dialogAdditionalText = '';  
    this.showDialog.set(false);

    if($event && this._artworkToUpdate()) {
      this.deleteArtworkService.id.set(this._artworkToUpdate()!.id);
    }   
  }

  private loadById(): void {
    if(this.id() && !isNaN(parseInt(this.id()?.toString() ?? ''))) {
        const params: Map<string, any> = new Map<string, any>([
        ['id', this.id()]
      ]);
      this.isUpdateMode.set(true);
      this.getByIdArtworkService.params.set(params);     
    } else {
      this.isUpdateMode.set(false);
      this._artworkToUpdate.set(undefined);
    }
  }

  private getFormData(data: CreateOrUpdateArtworkInterface, file?: File): FormData {
    const form = new FormData();

    if(file) {
      form.append('file', file);
    }        
  
    if (data.id) {  
      form.append('Id', data.id.toString());
    }  

    form.append('Name', data.name);          
    form.append('Description', data.description);  
    form.append('ArtistId', data.artistId.toString());     

    return form;
  }

}
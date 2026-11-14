import { Component, effect, inject, signal, WritableSignal } from '@angular/core';
import { Loading } from '../../services/loading/loading';

@Component({
  imports: [],
  selector: 'app-spinner',
  styleUrl: './spinner.scss',
  templateUrl: './spinner.html',
})
export class Spinner {

  protected showSpinner: WritableSignal<boolean> = signal(false);

  private loadingService = inject(Loading);

  constructor() {
    effect(() => {
      const isLoading: boolean = this.loadingService.isLoading();
      this.showSpinner.set(isLoading);
    });
  }

}
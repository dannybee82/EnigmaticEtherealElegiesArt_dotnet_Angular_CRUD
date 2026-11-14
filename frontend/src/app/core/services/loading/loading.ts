import { Service, signal, WritableSignal } from '@angular/core';

@Service()
export class Loading {

    isLoading: WritableSignal<boolean> = signal<boolean>(false);

}

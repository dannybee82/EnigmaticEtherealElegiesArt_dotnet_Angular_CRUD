import { Component, input, InputSignal, output, OutputEmitterRef } from '@angular/core';
import { MatIconModule } from '@angular/material/icon'; 
import { MatButtonModule } from '@angular/material/button';
import { DialogInterface } from '../../models/dialogs/dialog.interface';
import { DialogType } from '../../models/dialogs/dialog-type.enum';

@Component({
  selector: 'app-dialog',
  imports: [MatIconModule, MatButtonModule],
  templateUrl: './dialog.html',
  styleUrl: './dialog.scss'
})
export class Dialog {

  readonly dialog: InputSignal<DialogInterface | null> = input<DialogInterface | null>(null);

  readonly getConfirmation: OutputEmitterRef<boolean> = output<boolean>()

  closeDialog() : void {
    this.getConfirmation.emit(false);
  }

  cancel() : void {
    this.getConfirmation.emit(false);
  }

  ok() : void {
    this.getConfirmation.emit(true);
  }

  getType(): typeof DialogType {
    return DialogType;
  }

}
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent {
  @Output() onClickEvent = new EventEmitter<boolean>();

  onClickYes() {
    this.onClickEvent.emit(true);
  }
  onClickNo() {
    this.onClickEvent.emit(false);
  }
}

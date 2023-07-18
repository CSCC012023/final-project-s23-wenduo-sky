import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { ToasterComponent } from './components/toaster/toaster.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    ToasterComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    NgbModule
  ],
  exports: [
    ConfirmationDialogComponent,
    ToasterComponent
  ]
})
export class SharedModule { }

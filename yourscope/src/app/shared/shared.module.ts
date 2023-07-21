import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselComponent } from './components/carousel/carousel.component';


@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    CarouselComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    NgbCollapse
  ],
  exports: [
    ConfirmationDialogComponent,
    CarouselComponent
  ]
})
export class SharedModuleV2 { }

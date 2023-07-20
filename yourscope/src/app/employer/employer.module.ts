import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { EmployerRoutingModule } from './employer-routing.module';
import { DashboardEmployerComponent } from './dashboard-employer/dashboard-employer.component';
import { EmployerPostingComponent } from './employer-posting/employer-posting.component';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';

import { JobPostingComponent } from './job-posting/job-posting.component';
import { JobPostingCreateComponent } from './job-posting-create/job-posting-create.component';

@NgModule({
  declarations: [
    DashboardEmployerComponent,
    EmployerPostingComponent,
    JobPostingComponent,
    JobPostingCreateComponent,
  ],
  imports: [
    CommonModule,
    EmployerRoutingModule,
    NgbCollapse, 
    BrowserModule,
    ReactiveFormsModule
  ]
})
export class EmployerModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentRoutingModule } from './student-routing.module';
import { DashboardStudentComponent } from './dashboard-student/dashboard-student.component';
import { StudentCoursesComponent } from './student-courses/student-courses.component';
import { StudentPostingsComponent } from './student-postings/student-postings.component';
import { StudentEventsComponent } from './student-events/student-events.component';
import { StudentEventDetailsComponent } from './student-event-details/student-event-details.component';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { TruncatePipe } from '../pipes/truncate.pipe';
import { StudentPostingDetailsComponent } from './student-posting-details/student-posting-details.component';
import { CreateProfileComponent } from './create-profile/create-profile.component';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';

@NgModule({
  declarations: [
    DashboardStudentComponent,
    StudentPostingsComponent,
    StudentEventsComponent,
    StudentEventDetailsComponent,
    StudentCoursesComponent,
    TruncatePipe,
    StudentPostingDetailsComponent,
    ProfileComponent,
    CreateProfileComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    NgbCollapse,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class StudentModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentRoutingModule } from './student-routing.module';
import { DashboardStudentComponent } from './dashboard-student/dashboard-student.component';
import { StudentCoursesComponent } from './student-courses/student-courses.component';
import { StudentPostingsComponent } from './student-postings/student-postings.component';
import { StudentEventsComponent } from './student-events/student-events.component';
import { StudentEventDetailsComponent } from './student-event-details/student-event-details.component';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { StudentPostingDetailsComponent } from './student-posting-details/student-posting-details.component';
import { CourseComponent } from './course/course.component';
import { YearComponent } from './year/year.component';
import { ViewCourseComponent } from './view-course/view-course.component';
import { AddCourseComponent } from './add-course/add-course.component';
import { CreateProfileComponent } from './create-profile/create-profile.component';
import { ProfileComponent } from './profile/profile.component';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { SharedModule } from '../shared.module';
import { SharedModuleV2 } from '../shared/shared.module';
import { StudentApplicationComponent } from './student-application/student-application.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@NgModule({
  declarations: [
    DashboardStudentComponent,
    StudentEventsComponent,
    StudentPostingsComponent,
    StudentEventDetailsComponent,
    StudentCoursesComponent,
    StudentPostingDetailsComponent,
    CourseComponent,
    YearComponent,
    ViewCourseComponent,
    AddCourseComponent,
    ProfileComponent,
    CreateProfileComponent,
    StudentPostingDetailsComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    StudentApplicationComponent,
    NgbCollapse,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    SharedModuleV2,
    MatSlideToggleModule
  ]
})
export class StudentModule { }

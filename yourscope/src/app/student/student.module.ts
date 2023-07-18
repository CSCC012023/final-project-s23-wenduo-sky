import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { StudentRoutingModule } from './student-routing.module';
import { DashboardStudentComponent } from './dashboard-student/dashboard-student.component';
import { StudentCoursesComponent } from './student-courses/student-courses.component';
import { StudentPostingsComponent } from './student-postings/student-postings.component';
import { StudentEventsComponent } from './student-events/student-events.component';
import { StudentEventDetailsComponent } from './student-event-details/student-event-details.component';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { TruncatePipe } from '../pipes/truncate.pipe';
import { StudentPostingDetailsComponent } from './student-posting-details/student-posting-details.component';
import { CourseComponent } from './course/course.component';
import { YearComponent } from './year/year.component';
import { ViewCourseComponent } from './view-course/view-course.component';
import { AddCourseComponent } from './add-course/add-course.component';

@NgModule({
  declarations: [
    DashboardStudentComponent,
    StudentPostingsComponent,
    StudentEventsComponent,
    StudentEventDetailsComponent,
    StudentCoursesComponent,
    TruncatePipe,
    StudentPostingDetailsComponent,
    CourseComponent,
    YearComponent,
    ViewCourseComponent,
    AddCourseComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    NgbCollapse,
    SharedModule
  ]
})
export class StudentModule { }

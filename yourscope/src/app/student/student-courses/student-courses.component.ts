import { Component, OnInit } from '@angular/core';
import { APIService } from '../../services/api.service';
import { CookieService } from 'ngx-cookie-service';
import { JwtService } from 'src/app/services/jwt.service';
import { YearCourse } from '../year/year.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-student-courses',
  templateUrl: './student-courses.component.html',
  styleUrls: ['./student-courses.component.scss']
})
export class StudentCoursesComponent {
  // Constants
  animationDuration: number = 150;
  collapsed: boolean = true;
  // Class fields
  scheduleLoaded = false;
  showAddCourse = false;
  showViewCourse = false;
  // For animations
  viewCourseDiv = true;
  schedule: StudentSchedule = new StudentSchedule(-1, -1, []);
  viewCourse: YearCourse | null = null;
  // Constructor
  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService) {}
  // Initialization
  async ngOnInit(): Promise<void> {
    // Getting the user information.
    const user = JSON.parse(this.cookie.get('userObject'));
    let userID = user.userId;

    let result = await this.api.getStudentSchedule(userID);

    if (result == undefined) {
      await this.api.createStudentSchedule(userID);
      result = await this.api.getStudentSchedule(userID);
    }

    // Setting the schedule object.
    this.schedule = result;
    this.scheduleLoaded = true;
  }
  // Methods
  onClickViewCourse(yearCourse: YearCourse) {
    this.viewCourse = yearCourse;
    this.showViewCourse = true;
    this.viewCourseDiv = true;
  }
  onClickAddCourse(yearNumber: number) {
    this.showAddCourse = true;
  }
  onClickBackground(event: any) {
    if (event.target.classList.contains("overlayBackground")) {
      this.viewCourseDiv = false;
      setTimeout(() => this.closeOverlay(), this.animationDuration + 150);
    }
  }
  onClickClose() {
    this.viewCourseDiv = false;
    setTimeout(() => this.closeOverlay(), this.animationDuration + 150);
  }
  closeOverlay() {
    this.showAddCourse = false;
    this.showViewCourse = false;
  }
  onCourseDeleted() {
    this.closeOverlay();
    this.schedule = new StudentSchedule(-1, -1, []);
    this.scheduleLoaded = false;
    this.ngOnInit();
  }
}

export class StudentSchedule {
  scheduleId: number;
  studentId: number;
  years: Array<any>;

  constructor(scheduleId: number, studentId: number, years: Array<any>) {
    this.scheduleId = scheduleId;
    this.studentId = studentId;
    this.years = years;
  }
}

import { Component, OnInit } from '@angular/core';
import { APIService } from '../../services/api.service';
import { CookieService } from 'ngx-cookie-service';
import { JwtService } from 'src/app/services/jwt.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-student-courses',
  templateUrl: './student-courses.component.html',
  styleUrls: ['./student-courses.component.scss']
})
export class StudentCoursesComponent {
  collapsed: boolean = true;
  // Constants
  scheduleYearPrefix: string = "scheduleYear";
  courseIndices = Array(8).fill(0).map((_, i) => i);
  // Class fields
  yearNumbers = [1, 2, 3, 4];
  schedule: StudentSchedule = new StudentSchedule(-1, -1, []);
  // Constructor
  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService) {}
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

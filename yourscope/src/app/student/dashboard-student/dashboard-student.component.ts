import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-dashboard-student',
  templateUrl: './dashboard-student.component.html',
  styleUrls: ['./dashboard-student.component.scss']
})
export class DashboardStudentComponent implements OnInit {
  collapsed = true;
  events: any = [];
  jobs: any = [];
  currentCourses = [
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'}
  ];
  previousCourses = [
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering'}
  ];
  eventsWidth = 323;
  jobsWidth = 323;

  constructor(private api: APIService) { }

  ngOnInit() {
    let url = 'https://localhost:7184/api/events/v1?count=10';
    this.api.get(url).subscribe((res: any) => {
      this.events = res.data;
      this.eventsWidth = this.eventsWidth * this.events.length;
    });
    url = 'https://localhost:7184/api/job/v1/posting?count=10';
    this.api.get(url).subscribe((res: any) => {
      this.jobs = res.data;
      this.jobsWidth = this.jobsWidth * this.jobs.length;
    });
  }
}
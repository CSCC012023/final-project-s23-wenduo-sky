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
  events = [
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'},
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'},
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'},
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'},
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'},
    {title: 'Event', time: 'NOW', desc: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'}
  ];
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
    const url = 'https://localhost:7184/api/job/v1/posting?count=10';
    this.api.get(url).subscribe(res => {
      this.jobs = res;
      this.eventsWidth = this.eventsWidth * this.events.length;
      this.jobsWidth = this.jobsWidth * this.jobs.length;
    });
  }
}

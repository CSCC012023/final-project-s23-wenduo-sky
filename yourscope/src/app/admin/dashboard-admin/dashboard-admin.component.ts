import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { APIService } from 'src/app/services/api.service';
import { JwtService } from 'src/app/services/jwt.service';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss']
})
export class DashboardAdminComponent implements OnInit{
  events: any[] = [];
  eventStates: boolean[] = [];
  courses = [
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
    {code: 'CSCC01', name: 'Introduction to Software Engineering', url: '#'},
  ];

  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService) { }

  token = this.jwt.DecodeToken(this.cookie.get("loginToken"));
  
  ngOnInit(): void {
    this.api.getEvents(20, 0, this.token.affiliationID, undefined).subscribe({
      next: res => {
        this.events = JSON.parse(JSON.stringify(res)).data;
        for (let i = 0; i < this.events.length; i++) {
          this.eventStates.push(false);
        }
      }, 
      error: err => {
        alert("Unable retrieve events." );
      }
    });
  }

  toggleEventState(index: number): void {
    this.eventStates[index] = !this.eventStates[index];
  }
}

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
  events = <any> [];

  constructor(private hc: APIService, private cookie: CookieService, private jwtService: JwtService) { }

  ngOnInit(): void {
    let loginToken = this.cookie.get("loginToken");
    let decodedToken = this.jwtService.DecodeToken(loginToken);
    
    this.hc.getEvents(0,10, undefined, decodedToken.userId).subscribe({
      next: res => {
        this.events = JSON.parse(JSON.stringify(res)).data;

        for (let event in this.events){
            let date = this.events[event].date;
            date = new Date(date).toLocaleDateString('en-US'); 
            this.events[event].date = date;
        }
      }, 
      error: err => {
        alert("Couldn't retrieve events" );
      }
    });
  }

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
}

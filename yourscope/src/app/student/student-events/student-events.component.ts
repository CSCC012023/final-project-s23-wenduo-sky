import { Component, OnInit } from '@angular/core';
import { APIService } from '../../services/api.service';
import { CookieService } from 'ngx-cookie-service';
import { JwtService } from 'src/app/services/jwt.service';
import { NumberInput } from '@angular/cdk/coercion';

interface event {
  eventId: number,
  title: string,
  description: string,
  date: string,
  location: string,
  userId: number | null,
  user: number | null,
  schoolId: number | null,
  school: number | null
}

@Component({
  selector: 'app-student-events',
  templateUrl: './student-events.component.html',
  styleUrls: ['./student-events.component.scss']
})

export class StudentEventsComponent implements OnInit {
  collapsed : boolean = false;
  popup : boolean = false; 
  selected : event = {eventId: -1, title: "", date: "", description: "", location: "", userId:  null, user:  null, schoolId:  null, school:  null};

  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService) {}

  loadPopup(e: event) {
    this.popup = true;
    this.selected = e;
  }

  closePopup1() {
    this.popup = false;
  }

  closePopup2(t: MouseEvent) {
    if ((t.target as Element).className == "close-popup") this.popup = false;
  }

  events: event[] = [];
  col1: event[] = [];
  col2: event[] = [];
  col3: event[] = [];
  col4: event[] = [];

  ngOnInit() {
    let loginToken = this.cookie.get("loginToken");
    let decodedToken = this.jwt.DecodeToken(loginToken);
    this.api.getEvents(0,10, decodedToken.affiliationID, undefined).subscribe({
      next: res => {
        this.events = JSON.parse(JSON.stringify(res)).data;
        console.log(res);

        for (let event in this.events){
            let date = this.events[event].date;
            date = new Date(date).toLocaleDateString('en-US'); 
            this.events[event].date = date;
        }

        this.col1 = this.events.filter((v, i) => i % 4 == 0);
        this.col2 = this.events.filter((v, i) => i % 4 == 1);
        this.col3 = this.events.filter((v, i) => i % 4 == 2);
        this.col4 = this.events.filter((v, i) => i % 4 == 3);
      }, 
      error: err => {
        alert("Couldn't retrieve events" );
      }
    });
  }
}

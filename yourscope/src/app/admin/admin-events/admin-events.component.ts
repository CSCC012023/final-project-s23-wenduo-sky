import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { APIService } from 'src/app/services/api.service';
import { JwtService } from 'src/app/services/jwt.service';

@Component({
  selector: 'app-admin-events',
  templateUrl: './admin-events.component.html',
  styleUrls: ['./admin-events.component.scss']
})
export class AdminEventsComponent implements OnInit {
  events = <any> [];
  popup: boolean = false; 
  selected: any = {};
  currentPage: number = 1;
  totalPages: number = 0;

  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService) { }

  ngOnInit(): void {
    const token = this.jwt.DecodeToken(this.cookie.get("loginToken"));
    this.api.getEventCount(token.affiliationId, undefined).subscribe((res: any) => {
      this.totalPages = Math.ceil(res.data / 12);
      console.log(this.totalPages);
    })
    this.updatePage();
  }

  deleteEvent(e: any){
    this.api.deleteEvent(e.eventId).subscribe({
      next: res => {
        alert("Successfully deleted event.");
        location.reload();
      }, 
      error: err => {
        alert("Unable to delete event.");
      }
    });
  }

  loadPopup(e: any) {
    this.popup = true;
    this.selected = e;
  }

  closePopup1() {
    this.popup = false;
  }

  closePopup2(t: MouseEvent) {
    if ((t.target as Element).className == "close-popup") this.popup = false;
  }

  onPageChange(page: number) {
    this.currentPage = page;
    this.updatePage();
  }

  onPageMove(increment: boolean) {
    if (this.totalPages == 0) {
      return;
    }
    if (increment) {
      if (this.currentPage == this.totalPages) {
        return;
      }
      this.currentPage++;
    } else {
      if (this.currentPage == 1) {
        return;
      }
      this.currentPage--;
    }
    this.updatePage();
  }

  updatePage() {
    const token = this.jwt.DecodeToken(this.cookie.get("loginToken"));
    this.api.getEvents(12, (this.currentPage - 1) * 12, token.affiliationID, undefined).subscribe({
      next: (res: any) => {
        this.events = res.data
      },
      error: err => {
        alert("Unable to retrieve events.");
      }
    });
  }
}


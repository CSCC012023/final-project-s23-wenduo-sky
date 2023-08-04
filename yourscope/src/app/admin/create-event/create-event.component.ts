import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent {
  title : string = '';
  eventDate : Date = new Date(0);
  location : string = '';
  description : string = '';
  
  constructor(private router : Router, private hc : APIService, private toastr: ToastrService) { }

  save() {
    let currentDate = Date.now();
    currentDate = new Date(currentDate).setHours(0,0,0,0);

    if(this.title == '') {
      this.toastr.error("Please enter event name.");
      return;
    }
    if(this.description == '') {
      this.toastr.error("Please enter event description.");
      return;
    }
    
    if(currentDate - new Date(this.eventDate).getTime() > new Date().getTimezoneOffset() * 60000) {
      this.toastr.error("Please enter a future date for the event.");
      return;
    }
    if(this.location == '') {
      this.toastr.error("Please enter event location.");
      return;
    }
    

    this.hc.createEvent(this.title, this.description, this.eventDate, this.location).subscribe({
      next: res => {
        this.toastr.success("Successfully created event.");
        this.router.navigate(['/admin/events']);
      }, 
      error: err => {
        this.toastr.error("Unable to create event.");
      }
    });
  }
}

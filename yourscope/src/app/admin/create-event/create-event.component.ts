import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent {
  name : string = '';
  eventDate : string = '' ;
  location : string = '';
  description : string = '';
  
  constructor(private router : Router) { }

  save() {
    if(this.name == '') {
      alert('Please enter event name');
      return;
    }

    if(Date.parse(this.eventDate) < Date.now()) {
      alert('Please enter a future date for the event');
      return;
    }
    if(this.location == '') {
      alert('Please enter event location');
      return;
    }
    if(this.description == '') {
      alert('Please enter event description');
      return;
    }

    this.router.navigate(['/admin/events']);
  }
}

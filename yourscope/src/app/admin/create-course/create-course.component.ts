import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss']
})
export class CreateCourseComponent {
  code : string = '';
  name : string = '';
  description : string = '';
  discipline: string = '';
  type : string = '';
  grade : number | string = '';
  credits : number | string = '';
  prerequisites : string = '';
  
  constructor(private router : Router, private hc : APIService, private toastr: ToastrService) { }

  save() {
    if(this.code == '') {
      this.toastr.error("Please enter course code.");
      return;
    }
    if(this.description == '') {
      this.toastr.error("Please enter course description.");
      return;
    }
    if(this.name == '') {
      this.toastr.error("Please enter course name.");
      return;
    }
    if(this.discipline == '') {
      this.toastr.error("Please enter course discipline.");
      return;
    }
    if(this.type == '') {
      this.toastr.error("Please enter course type.");
      return;
    }
    if(this.credits == '' || <number>this.credits < 1) {
      this.toastr.error("Please enter a valid number of credits.");
      return;
    }
    if(this.grade == '' || <number>this.grade < 9) {
      this.toastr.error("Please enter a valid grade.");
      return;
    }

    this.hc.createCourse(this.code, this.name, this.discipline, this.type, <number>this.grade, <number>this.credits, this.description, this.prerequisites).subscribe({
      next: res => {
        this.toastr.success("Successfully added course.");
        this.router.navigate(['/admin/courses']);
      }, 
      error: err => {
        this.toastr.error("Unable to add course.");
      }
    });
  }
}

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { APIService } from 'src/app/services/api.service';
import { JwtService } from 'src/app/services/jwt.service';
import { StudentSchedule } from '../student-courses/student-courses.component';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.scss']
})
export class AddCourseComponent {
  @Input() yearNumber: number = 0;
  @Output() onCourseAdded = new EventEmitter<void>();
  schedule: StudentSchedule = new StudentSchedule(-1, -1, []);
  allCourses = <any> [];
  popup: boolean = false; 
  confirmNoPrereqs: boolean = false;
  confirmWithPrereqs: boolean = false;
  selected: any = {};
  currentPage: number = 1;
  totalPages: number = 0;
  showConfirmationDialog: boolean = false;
  currentCourses = <any> [];
  prerequisites = <any> [];
  coursePrereqs = "";

  
  constructor(private api: APIService, private cookie: CookieService, private jwt: JwtService, private router: Router) { }

  ngOnInit(): void {
    const token = this.jwt.DecodeToken(this.cookie.get("loginToken"));
    this.api.getCourseCount(token.affiliationID, undefined, undefined, undefined).subscribe((res: any) => {
      this.totalPages = Math.ceil(res.data / 12);
      console.log(this.totalPages);
    })
    this.updatePage();
  }

  addCourse(e: any){
    this.selected = e;
    this.checkCoursePrereqs();
  }

  async checkCoursePrereqs(){
    this.coursePrereqs = this.selected.prerequisites;
    console.log(this.coursePrereqs);
    if (this.coursePrereqs == ""){
      this.confirmNoPrereqs = true; 
    } else {
      this.prerequisites = this.coursePrereqs.split(",")
      
      const user = JSON.parse(this.cookie.get('userObject'));
      let userID = user.userId;
  
      let result = await this.api.getStudentSchedule(userID);

      this.schedule = result;

      this.prerequisites.forEach((courseID: string) => {
        this.schedule.years.forEach((year: any) => {
          year.courses.forEach((courseInfo: any) => {
            let modified_courseID = courseInfo.courseCode.substring(0,5)
            if (courseID == modified_courseID){
              this.confirmNoPrereqs = true; 
            }
          });
        });
      });
    }

    if(this.confirmNoPrereqs == false){
      this.confirmWithPrereqs = true; 
    }
  }

  confirmAddition(result: boolean) {
    this.confirmWithPrereqs = false;
    this.confirmNoPrereqs = false;
    if (result) {
      this.api.addCourseToSchedule(this.yearNumber, this.selected.courseId).subscribe({
        next: res => {
          this.onCourseAdded.emit()
        }, 
        error: err => {
          alert("Unable to add course.");
        }
      });
    }
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
    this.api.getCourses(token.affiliationID, undefined, undefined, undefined, (this.currentPage - 1) * 12, 12).subscribe({
      next: (res: any) => {
        this.allCourses = res.data
      },
      error: err => {
        alert("Unable to retrieve events.");
      }
    });
  }
}

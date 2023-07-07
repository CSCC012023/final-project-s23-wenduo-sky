import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { APIService } from '../../services/api.service';
import { Router } from '@angular/router';
import { AfterViewInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';

class UserObj {
  Email!: string;
  FirstName!: string;
  MiddleName!: string | null;
  LastName!: string;
  Birthday!: string | null;
  Role!: number;
  Affiliation!: string;
  Grade!: number | null;
  Password!: string;

  constructor(a: string, b: string, c: string | null, d: string, e: string | null, f: number, g: string, h: number | null, i: string) {
    this.Email = a;
    this.FirstName = b;
    this.MiddleName = c;
    this.LastName = d;
    this.Birthday = e;
    this.Role = f;
    this.Affiliation = g;
    this.Grade = h;
    this.Password = i;
  }
}

class School {
  schoolId: number;
  name: string;
  address: string | undefined;

  constructor(id: number, name: string, address: string | undefined) {
    this.schoolId = id;
    this.name = name;
    this.address = address;
  }
}

@Component({
  standalone: true,
  selector: 'app-register-student',
  templateUrl: './register-student.component.html',
  styleUrls: ['./register-student.component.scss'],
  imports: [
    BrowserModule,
    ReactiveFormsModule
  ]
})

export class RegisterStudentComponent {
  schools: School[] = [];
  constructor(private api: APIService, private router: Router, private auth: AuthService) { }

  public studentForm = new FormGroup({
    fname: new FormControl(),
    //mname: new FormControl(),
    lname: new FormControl(),
    email: new FormControl(),
    pass: new FormControl(),
    cpass: new FormControl(),
    school: new FormControl(),
    grade: new FormControl(),
    birthday: new FormControl()
  })

  ngAfterViewInit(): void {
    this.fetchAllSchools();
  }

  handleStudentRegistration() {
    let pass, cpass;

    if (this.studentForm.get("fname")!.value == null) return;
    if (this.studentForm.get("lname")!.value == null) return;
    if (this.studentForm.get("email")!.value == null) return;
    if (this.studentForm.get("pass")!.value != null && (this.studentForm.get("pass")!.value as string).length > 5) pass = this.studentForm.get("pass")!.value;
    else return;
    if (this.studentForm.get("cpass")!.value != null && (this.studentForm.get("cpass")!.value as string).length > 5) cpass = this.studentForm.get("cpass")!.value;
    else return;
    if (pass != cpass) return;
    if (this.studentForm.get("school")!.value == null) return;
    if (this.studentForm.get("grade")!.value == null) return;
    if (this.studentForm.get("birthday")!.value == null) return;

    const url = 'https://localhost:7184/api/accounts/v1/student/register';
    const user = new UserObj(
      this.studentForm.get("email")!.value,
      this.studentForm.get("fname")!.value,
      "",
      this.studentForm.get("lname")!.value,
      this.studentForm.get("birthday")!.value,
      0,
      this.studentForm.get("school")!.value,
      this.studentForm.get("grade")!.value,
      this.studentForm.get("pass")!.value
    );

    this.api.post(url, user).subscribe(() => {
      this.router.navigate(['/dashboardStudent']);
      this.auth.login(this.studentForm.get("email")!.value, this.studentForm.get("pass")!.value);
    });
  }

  populateSchoolList(schools : School[]): void {
    this.schools = schools;
  }

  fetchAllSchools() : void {
    const url = 'https://localhost:7184/api/schools/v1';
    var component = this;

    this.api.get(url).subscribe({
      next: res => {
        let response = JSON.parse(JSON.stringify(res));
        component.populateSchoolList(response.data);
      },
      error: err => {
        console.log(err.error);
      }
    });
  }
}

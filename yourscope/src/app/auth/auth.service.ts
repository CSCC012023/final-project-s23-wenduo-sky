import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { APIService } from '../services/api.service';
import { JwtService } from '../services/jwt.service';
import { CookieService } from 'ngx-cookie-service'

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private router : Router, private service : APIService, private jwtService : JwtService, private cookieService: CookieService)  { }

  login(email: string, password: string) {
    this.service.getLogin(email, password).subscribe({
      next: res => {
        let loginData = JSON.parse(JSON.stringify(res));
        let loginToken = this.jwtService.DecodeToken(loginData.data);
        if(loginToken.role === 0){
          this.router.navigate(['/dashboardStudent']);
        }
        else if(loginToken.role === 1){
          this.router.navigate(['/dashboardAdmin']);
        }
        else{
          this.router.navigate(['/dashboardEmployer']);
        }

        this.cookieService.set('loginToken', loginData.data);
      }, 
      error: err => {
        alert(err.error);
      }
    });
  }
  
  passwordReset(email: string) {
    this.service.passwordReset(email).subscribe({
      next: () => {
        alert("Email sent");
        this.router.navigate(['/login']);
      }, 
      error: err => {
        alert(err.error);
      }
    });
  }
}


export class User {
  userId: number;
  email: string;
  firstName: string;
  middleName: string | undefined;
  lastName: string;
  birthday: Date;
  role: number;
  affiliation: string;
  affiliationID: number | undefined;
  grade: number;

  constructor(id: number, email: string, firstName: string, middleName: string | undefined, lastName: string, birthday: Date, role: number, affiliation: string, affiliationID: number, grade: number) {
    this.userId = id;
    this.email = email;
    this.firstName = firstName;
    this.middleName = middleName;
    this.lastName = lastName;
    this.birthday = birthday;
    this.role = role;
    this.affiliation = affiliation;
    this.affiliationID = affiliationID;
    this.grade = grade;
  }
}
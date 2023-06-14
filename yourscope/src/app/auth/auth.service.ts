import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { APIService } from '../services/api.service';
import { JwtService } from '../services/jwt.service';

@Injectable({
  providedIn: 'root'
})

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private router : Router, private service : APIService, private jwtService : JwtService)  { }

  login(email: string, password: string) {
    this.service.getLogin(email, password).subscribe({
      next: res => {
        let loginToken = this.jwtService.DecodeToken(res.toString());
        if(loginToken.role === 0){
          this.router.navigate(['/dashboardStudent']);
        }
        if(loginToken.role === 1){
          this.router.navigate(['/dashboardEmployer']);
        }
        if(loginToken.role === 2){
          this.router.navigate(['/dashboardAdmin']);
        }
      }, 
      error: err => {
        alert(err.error);
      }
    });
  }
}

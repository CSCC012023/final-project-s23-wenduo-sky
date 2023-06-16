import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { APIService } from '../services/api.service';

@Injectable({
  providedIn: 'root'
})

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private router : Router, private service : APIService)  { }

  login() {
    this.router.navigate(['/dashboardStudent']);
  }

  passwordReset(email: string) {
    this.service.passwordReset(email).subscribe({
      next: res => {
        alert("Email sent");
        this.router.navigate(['/login']);
      }, 
      error: err => {
        alert(err.error);
      }
    });
  }
}

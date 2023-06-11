import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private fireauth : AngularFireAuth, private router : Router)  { }

  login(email : string, password : string) {
    this.fireauth.signInWithEmailAndPassword(email,password).then( res => {
        localStorage.setItem('token','true');
        this.router.navigate(['/dashboardStudent']);
    }, err => {
        alert(err.message);
        this.router.navigate(['/login']);
    })
  }
}

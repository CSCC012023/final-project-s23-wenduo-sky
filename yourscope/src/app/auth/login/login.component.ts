import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email : string = '';
  password : string = '';

  constructor(private auth : AuthService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    if(this.email == '') {
      this.toastr.error("Please enter an email.");
      return;
    }

    if(this.password == '') {
      this.toastr.error("Please enter a password.");
      return;
    }

    this.auth.login(this.email, this.password);
  }
}
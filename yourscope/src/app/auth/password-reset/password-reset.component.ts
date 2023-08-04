import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.scss']
})
export class PasswordResetComponent implements OnInit{
    email : string = '';

    constructor(private auth : AuthService, private toastr: ToastrService) { }

    ngOnInit(): void {
    }

    resetPassword(){
      if (this.email == '') {
        this.toastr.error("Please enter an email.");
      return;
      }
      this.auth.passwordReset(this.email);
    }
}

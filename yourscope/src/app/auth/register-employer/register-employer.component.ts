import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { APIService } from '../../services/api.service';

class userObj {
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

@Component({
  standalone: true,
  selector: 'app-register-employer',
  templateUrl: './register-employer.component.html',
  styleUrls: ['./register-employer.component.scss'],
  imports: [
    BrowserModule,
    ReactiveFormsModule
  ]
})
export class RegisterEmployerComponent {

  constructor(private api: APIService) { }

  public employerForm = new FormGroup({
    fname: new FormControl(),
    mname: new FormControl(),
    lname: new FormControl(),
    email: new FormControl(),
    pass: new FormControl(),
    cpass: new FormControl()
  })

  handleEmployerRegistration() {
    let pass, cpass;

    if (this.employerForm.get("fname")!.value == "") return;
    if (this.employerForm.get("lname")!.value == "") return;
    if (this.employerForm.get("email")!.value == "") return;
    if (this.employerForm.get("pass")!.value != "" && (this.employerForm.get("pass")!.value as string).length > 5) pass = this.employerForm.get("pass")!.value;
    else return;
    if (this.employerForm.get("cpass")!.value != "" && (this.employerForm.get("cpass")!.value as string).length > 5) cpass = this.employerForm.get("cpass")!.value;
    else return;
    if (pass != cpass) {console.log(pass, cpass); return;}

    const url = 'https://localhost:7184/api/Accounts/v1/employer/register';
    const user = new userObj(
      this.employerForm.get("email")!.value,
      this.employerForm.get("fname")!.value,
      this.employerForm.get("mname")!.value,
      this.employerForm.get("lname")!.value,
      null,
      2,
      localStorage.getItem("companyName")!,
      null,
      this.employerForm.get("pass")!.value
    );
    this.api.post(url, user).subscribe(res => {
      console.log(res);
      if (res) localStorage.removeItem("companyName");
    });
  }
}

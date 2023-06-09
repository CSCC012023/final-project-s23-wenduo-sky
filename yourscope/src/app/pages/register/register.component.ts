import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  public regState: number = 0;

  loadStudentRegistraion(){
    this.regState = 1;
  }

  loadEmployerRegistraion(){
    this.regState = 2;
  }

}

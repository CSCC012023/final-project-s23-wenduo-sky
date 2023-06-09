import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { LandingComponent } from './landing/landing.component';
import { RouterModule, Routes } from '@angular/router';
import { RegisterStudentComponent } from './auth/register-student/register-student.component';
import { RegisterEmployerComponent } from './auth/register-employer/register-employer.component';

const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
]

@NgModule({
  declarations: [
    LandingComponent,
    LoginComponent,
    RegisterComponent,
    ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    RegisterStudentComponent,
    RegisterEmployerComponent
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

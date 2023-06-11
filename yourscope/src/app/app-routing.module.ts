import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { LandingComponent } from './landing/landing.component';
import { RouterModule, Routes } from '@angular/router';
import { RegisterStudentComponent } from './auth/register-student/register-student.component';
import { RegisterEmployerComponent } from './auth/register-employer/register-employer.component';
import { FormsModule } from '@angular/forms';
import { DashboardStudentComponent } from './student/dashboard-student/dashboard-student.component';
import { DashboardAdminComponent } from './admin/dashboard-admin/dashboard-admin.component';
import { DashboardEmployerComponent } from './employer/dashboard-employer/dashboard-employer.component';

const routes: Routes = [
  { path: '', component: LandingComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboardStudent', component: DashboardStudentComponent },
  { path: 'dashboardAdmin', component: DashboardAdminComponent },
  { path: 'dashboardEmployer', component: DashboardEmployerComponent }
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
    RegisterEmployerComponent,
    FormsModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

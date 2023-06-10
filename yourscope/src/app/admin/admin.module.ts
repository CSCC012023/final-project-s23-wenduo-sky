import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { Routes, RouterModule } from '@angular/router'; 
import { AdminRoutingModule } from './admin-routing.module';

const routes: Routes = [
  {   path: '',   component: DashboardComponent},
  {   path: 'admin',   component: DashboardComponent,
      children :[
          { path: 'dashboard', component: DashboardComponent},
      ]
  },
];

@NgModule({
  declarations: [
    DashboardComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
  ],
  exports: [RouterModule]
})
export class AdminModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminModule } from './admin.module';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {   path: '',   component: DashboardComponent},
  {   path: 'admin',   component: DashboardComponent}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)  
  ],
  exports: [RouterModule]
})

export class AdminRoutingModule { }

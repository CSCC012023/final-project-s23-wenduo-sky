import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { initializeApp,provideFirebaseApp } from '@angular/fire/app';
import { environment } from '../environments/environment';
import { provideAuth,getAuth, onIdTokenChanged } from '@angular/fire/auth';
import { provideDatabase,getDatabase } from '@angular/fire/database';
import { provideRemoteConfig,getRemoteConfig } from '@angular/fire/remote-config';
import { AppRoutingModule } from './app-routing.module';
import { AdminModule } from './admin/admin.module';
import { EmployerModule } from './employer/employer.module';
import { StudentModule } from './student/student.module';
import { CommonModule } from '@angular/common';
import {AngularFireModule} from '@angular/fire/compat';
import { PasswordResetComponent } from './auth/password-reset/password-reset.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    PasswordResetComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    provideFirebaseApp(() => initializeApp(environment.firebase)),
    provideAuth(() => getAuth()),
    provideDatabase(() => getDatabase()),
    provideRemoteConfig(() => getRemoteConfig()),
    AppRoutingModule,
    AdminModule,
    StudentModule,
    EmployerModule,
    AngularFireModule.initializeApp(environment.firebase),
    CommonModule, 
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

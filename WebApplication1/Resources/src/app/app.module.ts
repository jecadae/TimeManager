import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';


import { MatNativeDateModule } from '@angular/material/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { ModalWindowComponent } from './components/modal-window/modal-window.component';
import { MyPlanComponent } from './components/my-plan/my-plan.component';
import { NavigationBarComponent } from './components/navigation-bar/navigation-bar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProfileComponent } from './components/profile/profile.component';

import { AuthService } from './components/authentication/auth.service'
import { CheckDataService } from './components/authentication/check-data.service'
import { LoginComponent } from './components/authentication/login/login.component';
import { NewPasswordComponent } from './components/authentication/new-password/new-password.component';
import { PasswordResetComponent } from './components/authentication/password-reset/password-reset.component';
import { RegistrationComponent } from './components/authentication/registration/registration';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotFoundComponent,
    PasswordResetComponent,
    RegistrationComponent,
    NewPasswordComponent,
    NavigationBarComponent,
    HomePageComponent,
    MyPlanComponent,
    MyPlanComponent,
    ProfileComponent,

  ],

  entryComponents: [
    ModalWindowComponent
  ],

  imports: [
    MatFormFieldModule,
    MatDialogModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule
  ],

  providers: [
    {
      provide: MatDialogRef,
      useValue: {}
    },
    CheckDataService,
    AuthService],

  bootstrap: [AppComponent]
})

export class AppModule { }

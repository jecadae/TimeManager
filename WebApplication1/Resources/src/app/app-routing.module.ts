import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NewPasswordComponent } from './components/new-password/new-password.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PasswordResetComponent } from './components/password-reset/password-reset.component';
import { RegistrationComponent } from './components/registration/registration';
import { HomePageComponent } from './home-page/home-page.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo:'/login', pathMatch: 'full'},
  {path: '***', component: NotFoundComponent},
  {path: 'password-reset', component: PasswordResetComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'new-password', component:NewPasswordComponent},
  {path: 'home-page', component: HomePageComponent}

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

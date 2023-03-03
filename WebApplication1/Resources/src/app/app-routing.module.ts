import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { NewPasswordComponent } from './components/authentication/new-password/new-password.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PasswordResetComponent } from './components/authentication/password-reset/password-reset.component';
import { RegistrationComponent } from './components/authentication/registration/registration';
import { HomePageComponent } from './components/home-page/home-page.component';
import { MyPlanComponent } from './components/my-plan/my-plan.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo:'/login', pathMatch: 'full'},
  {path: '***', component: NotFoundComponent},
  {path: 'password-reset', component: PasswordResetComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: 'new-password', component:NewPasswordComponent},
  {path: 'home-page', component: HomePageComponent},
  {path: 'my-plan', component: MyPlanComponent}

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

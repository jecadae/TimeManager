import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PasswordResetComponent } from './components/password-reset/password-reset.component';
import { Registration } from './components/registration/registration';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo:'/login', pathMatch: 'full'},
  {path: '***', component: NotFoundComponent},
  {path: 'password-reset', component: PasswordResetComponent},
  {path: 'registration', component: Registration}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

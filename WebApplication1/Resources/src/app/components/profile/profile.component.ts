import { Component, OnInit } from '@angular/core';
//import { CheckDataService } from '../check-data.service';
//import { AuthService } from '../auth.service';
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  surname: string = '';
  name: string = '';
  patronymic: string = '';
  OldPassword: string = '';
  NewPassword: string = '';
  NewPasswordRepeat: string = '';

  constructor(
    //private checkRegistration: CheckDataService,
    private http: HttpClient,
    private router: Router,
    //private auth: AuthService
  ) {}

  ngOnInit() {
  }
  
}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup

  constructor(){

  }

  SubmitLogin(){
    console.log(this.loginForm.value);
  }


  ngOnInit(): void{
    //this.loginForm = new FormGroup(controls: {
    //    'email': new FormControl(formState: '', ValidatorOrOpts: [Validators.required, Validators.email]),
    //    'password': new FormControl(formState: '', ValidatorOrOpts: [Validators.required, Validators.pattern(pattern: )])
    //})
  }
}
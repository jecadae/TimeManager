import { Component, OnInit } from '@angular/core';
import { LocalService } from '../Local.service';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http'
import { map, observeOn } from 'rxjs/operators';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { identity } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  
  // base64 = 'data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEASABIAAD//'
  // pathToSaveImage = './public/image.png'
  // surname: string = '';
  // name: string = '';
  // patronymic: string = '';
  // OldPassword: string = '';
  // NewPassword: string = '';
  // NewPasswordRepeat: string = '';
  // token: any;

  // constructor(
  //   //private checkRegistration: CheckDataService,
  //   private http: HttpClient,
  //   private router: Router,
  //   //private auth: AuthService
  // ) {}

  // //path = converBase64ToImage(this.base64, this.pathToSaveImage) //returns path /public/image.png

  // imageGet(id: number) {
  //   let headers = new HttpHeaders;
  //   headers.append('Content-Type', 'application/json');
  //   headers.append('accept', 'text/plain')
  //   headers.append('Authorization:','Bearer'+this.token);
  //   return this.http.get(
  //     'https://localhost:44393/Auth/UserIconController/GetIcon',
  //     {observe: 'response'}).subscribe({
  //       next:(response: HttpResponse<any>)=>{
  //           return response.body;
  //       },
  //       error:()=>{ alert('Ошибка!')},
  //     });
  // }

  // ngOnInit() {
  // }
  
  imageSrc: string = '';
   
  myForm = new FormGroup({
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  myName = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    surname: new FormControl('', [Validators.required, Validators.minLength(3)]),
    patronymic: new FormControl('', [Validators.required, Validators.minLength(3)]),
  });
 
  constructor(
    private http: HttpClient,
    private localStore: LocalService) { }
  get f(){
    return this.myForm.controls;
  }

  onFileChange(event:any) {
    const reader = new FileReader();
     
    if(event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);
     
      reader.onload = () => {
    
        this.imageSrc = reader.result as string;
    
        this.myForm.patchValue({
          fileSource: reader.result as string
        });
    
      };
    }
  }
   
  submit(){
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'text/plain')
    headers.append('Authorization:','Bearer');
    console.log(this.myForm.value);
    this.http.post('https://localhost:44393/UserIcon/AddUserIcon', this.myForm.value)
      .subscribe(res => {
        console.log(res);
        alert('Uploaded Successfully.');
      })
    return this.http.post('https://localhost:44393/UserIcon/AddUserIcon', this.myForm.value, {
      headers: headers
    })
  }

  save(){
    let headers = new HttpHeaders;
    headers.append('Content-Type', 'application/json');
    headers.append('accept', 'text/plain')
    headers.append('Authorization:','Bearer');
    console.log(this.myName.value);
    this.http.post('https://localhost:44393/Auth/rename', this.myName.value)
      .subscribe(res => {
        console.log(res);
        alert('Uploaded Successfully.');
      })
    return this.http.post('https://localhost:44393/UserIcon/AddUserIcon', this.localStore.saveData, {
        headers: headers
      })
  }

    ngOnInit() {
  }

}

import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalWindowComponent } from 'src/app/components/modal-window/modal-window.component';
import { Options } from '@angular-slider/ngx-slider';

@Component({
  selector: 'app-my-plan',
  templateUrl: './my-plan.component.html',
  styleUrls: ['./my-plan.component.css']
})
export class MyPlanComponent {

//  constructor(public dialog: MatDialog) {}

//  openDialog() {
//    this.dialog.open(ModalWindowComponent);
//  }
value: number = 100;
options: Options = {
  floor: 0,
  ceil: 200

}
}

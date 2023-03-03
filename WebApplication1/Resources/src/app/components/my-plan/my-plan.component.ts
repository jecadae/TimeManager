import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalWindowComponent } from 'src/app/modal-window/modal-window.component';

@Component({
  selector: 'app-my-plan',
  templateUrl: './my-plan.component.html',
  styleUrls: ['./my-plan.component.css']
})
export class MyPlanComponent {

  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(ModalWindowComponent);
  }


}

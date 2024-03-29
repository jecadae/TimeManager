import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ModalWindowComponent } from '../modal-window/modal-window.component';
import { MyPlanCardComponent } from '../my-plan-card/my-plan-card.component';
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-my-plan',
  templateUrl: './my-plan.component.html',
  styleUrls: ['./my-plan.component.css']
})
export class MyPlanComponent {

  constructor(
    public dialog: MatDialog,
    private http: HttpClient,
    private router: Router,
    //private auth: AuthService
    )  {}

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(ModalWindowComponent, {
      width: '733px',
      height: '576px',
    });
  }

  PlanRequest(){
    
  }

}

import { Component, OnInit, ViewChildren } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';
import { ViewChild, AfterViewInit } from '@angular/core';

const material = [
  MatFormFieldModule,
  MatInputModule
]

@Component({
  selector: 'app-modal-window',
  templateUrl: 'modal-window.component.html',
  styleUrls: ['./modal-window.component.css']
})


export class ModalWindowComponent implements OnInit, AfterViewInit {

  // @ViewChild('test') test: any;

  constructor(public dialogRef: MatDialogRef<ModalWindowComponent>) { }
  value: any = 'Clear me';

  ngAfterViewInit() {

    // if (this.checkDeadline = !this.checkDeadline) {
    //   this.test.nativeElement
    // }
  }
  ngOnInit() { }

  privacy: string = '';
  choicePrivacy: string[] = ['Скрыть задачу', 'Сделать задачу видимой'];

  checkDeadline: boolean = false;
  nameGoal: string = '';
  taskName: string = '';
  deadline: any = undefined;
  dayOfWeek: any = [];
  frequency: any = undefined;
  time: any = undefined;

  createGoal() {
    const goal = {
      nameGoal: this.nameGoal,
      task: {
        taskName: this.taskName,
        deadline: this.deadline,
        dayOfWeek: this.dayOfWeek,
        frequency: this.frequency,
        time: this.time
      }
    }
  }



}

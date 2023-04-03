import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

const material = [
  MatFormFieldModule, 
  MatInputModule
]

  @Component({
    selector: 'app-modal-window',
    templateUrl: 'modal-window.component.html',
    styleUrls: ['./modal-window.component.css']
  })


  export class ModalWindowComponent {

    constructor(public dialogRef: MatDialogRef<ModalWindowComponent>) {}
    value: any = 'Clear me';

    ngOnInit() {}

}


// import { Component, OnInit, NgModule } from '@angular/core';
// import { TestComponentComponent } from '../test-component/test-component.component';
// import {MatDialog, MatDialogRef} from '@angular/material/dialog';

// @Component({
//   selector: 'app-modal-window',
//   templateUrl: './modal-window.component.html',
//   styleUrls: ['./modal-window.component.css']
// })
// export class ModalWindowComponent implements OnInit {

//   nameGoal: any = undefined;
//   taskName: any = undefined;
//   deadline: any = undefined;
//   dayOfWeek: any = [];
//   frequency: any = undefined;
//   time: any = undefined;


//   constructor(public dialogRef: MatDialogRef<TestComponentComponent>) {}

//   ngOnInit(): void {
    
//   }

//   createGoal() {
//     const goal = {
//       nameGoal: this.nameGoal,
//       task: {
//         taskName: this.taskName,
//         deadline: this.deadline,
//         dayOfWeek: this.dayOfWeek,
//         frequency: this.frequency,
//         time: this.time
//       }
//       // need to create constructor for object "task"
//     }
//   }

// }

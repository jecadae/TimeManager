import { Component, OnInit, NgModule } from '@angular/core';

@Component({
  selector: 'app-modal-window',
  templateUrl: './modal-window.component.html',
  styleUrls: ['./modal-window.component.css']
})
export class ModalWindowComponent implements OnInit {

  nameGoal: any = undefined;
  taskName: any = undefined;
  deadline: any = undefined;
  dayOfWeek: any = [];
  frequency: any = undefined;
  time: any = undefined;


  constructor() {}

  ngOnInit(): void {
    
  }

//  createGoal() {
//    const goal = {
//      nameGoal: this.nameGoal,
  //    task: {
    //    taskName: this.taskName,
      //  deadline: this.deadline,
       // dayOfWeek: this.dayOfWeek,
        //frequency: this.frequency,
        //time: this.time
     // }
      // need to create constructor for object "task"
  //  }
 // }

}

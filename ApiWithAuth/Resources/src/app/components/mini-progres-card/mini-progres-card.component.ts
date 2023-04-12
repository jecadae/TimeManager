import { Component } from '@angular/core';
import { ProgressCardComponent } from 'src/app/components/progress-card/progress-card.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBar } from '@angular/material/progress-bar';
import { MatCard } from '@angular/material/card';

const material = [
  MatCard,
  MatProgressBar,
  MatFormFieldModule, 
  MatInputModule
]



@Component({
  selector: 'app-mini-progres-card',
  templateUrl: './mini-progres-card.component.html',
  styleUrls: ['./mini-progres-card.component.css']
})
export class MiniProgresCardComponent {
  userName: string = 'Иванов Иван Иванович'
  goal: string = 'Название цели'

    constructor(public dialog: MatDialog) {}

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(ProgressCardComponent, {
      width: '800px',
      height: '552.78px',
    });
  }

}

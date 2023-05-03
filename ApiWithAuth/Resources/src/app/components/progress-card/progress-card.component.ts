import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatProgressBar } from '@angular/material/progress-bar';

const material = [
  MatProgressBar,
]

@Component({
  selector: 'app-progress-card',
  templateUrl: './progress-card.component.html',
  styleUrls: ['./progress-card.component.css']
})

export class ProgressCardComponent {

  constructor(public dialogRef: MatDialogRef<ProgressCardComponent>) {}
  value: any = 'Clear me';

}

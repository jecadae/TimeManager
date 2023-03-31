import { Component } from '@angular/core';


@Component({
  selector: 'app-mini-progres-card',
  templateUrl: './mini-progres-card.component.html',
  styleUrls: ['./mini-progres-card.component.css']
})
export class MiniProgresCardComponent {
  userName: string = 'Иванов Иван Иванович'
  goal: string = 'Название цели'
}

import { Component } from '@angular/core';
import { HeroService } from './hero.service';
import { MessageService } from './message.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HeroService, MessageService]
})
export class AppComponent {
  title = 'Tour of Heroes';
}

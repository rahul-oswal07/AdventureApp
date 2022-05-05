import { Component } from '@angular/core';
import { AdventureService } from './adventure.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[AdventureService]
})
export class AppComponent {
  title = 'adventure-app';
}

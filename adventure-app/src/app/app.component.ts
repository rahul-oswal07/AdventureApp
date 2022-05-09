import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AdventureService } from './adventure.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[AdventureService]
})
export class AppComponent {
  userId = environment.userId;
  title = 'adventure-app';
}

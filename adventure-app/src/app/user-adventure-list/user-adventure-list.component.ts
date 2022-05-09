
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserAdventure } from '../user-adventure.model';
import { UserAdventureService } from '../user-adventure.service';

@Component({
  selector: 'app-user-adventure-list',
  templateUrl: './user-adventure-list.component.html',
  styleUrls: ['./user-adventure-list.component.css']
})
export class UserAdventureListComponent implements OnInit {
  userAdventures: UserAdventure[];
  constructor(private userAdventureService: UserAdventureService) { }

  ngOnInit(): void {
    this.loadAllUserAdventures(environment.userId);
  }

  loadAllUserAdventures(userId:number): void {
    this.userAdventureService.getAllUserAdventures(userId).subscribe((userAdventures) => {
      this.userAdventures = userAdventures;
    });
  }
}
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Question } from '../question.model';
import { UserAdventure } from '../user-adventure.model';
import { UserAdventureService } from '../user-adventure.service';

@Component({
  selector: 'app-user-adventure',
  templateUrl: './user-adventure.component.html',
  styleUrls: ['./user-adventure.component.css'],
  providers:[UserAdventureService]
})
export class UserAdventureComponent implements OnInit {
  userAdventure: UserAdventure;
  adventureId: number;
  questions: Question[]


  constructor(private userAdventureService: UserAdventureService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.adventureId = parseInt(params.get('id'));
      this.loadUserAdventure(environment.userId, this.adventureId);
    });
  }

  loadUserAdventure(userId: number, adventureId: number):void {
    this.userAdventureService.getAdventure(userId, adventureId).subscribe((useradventure) => {
      this.userAdventure = useradventure;
      this.questions = useradventure.question.questions;
    });
  }
}

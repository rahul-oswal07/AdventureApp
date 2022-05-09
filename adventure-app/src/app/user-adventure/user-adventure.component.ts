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
  userAdventureId: number;
  questions: Question[]


  constructor(private userAdventureService: UserAdventureService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.userAdventureId = parseInt(params.get('id'));
      this.loadUserAdventure(this.userAdventureId);
    });
  }

  loadUserAdventure(userAdventureId: number):void {
    this.userAdventureService.getUserAdventure(userAdventureId).subscribe((useradventure) => {
      this.userAdventure = useradventure;
      this.questions = useradventure.question.questions;
    });
  }
}

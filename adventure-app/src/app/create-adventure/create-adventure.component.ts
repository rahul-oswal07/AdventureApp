import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Adventure } from '../adventure.model';
import { AdventureService } from '../adventure.service';
import { Question } from '../question.model';

@Component({
  selector: 'app-create-adventure',
  templateUrl: './create-adventure.component.html',
  styleUrls: ['./create-adventure.component.css']
})
export class CreateAdventureComponent implements OnInit {

  adventure: Adventure;
  submitted: boolean;

  constructor(public adventureService: AdventureService, private router: Router) { }

  ngOnInit(): void {
    this.adventure = new Adventure();
    this.adventure.rootQuestion = new Question();
  }
  onSubmit() {
    console.log(this.adventure);
     this.submitted = true; 
     this.adventureService.createAdventure(this.adventure)
     .subscribe((item) => {
       if(item) {
        this.router.navigate([''])
       }
     });
    }

  addQuestion () {

    let yesQuestion = new Question();
    yesQuestion.value = true;
    let noQuestion = new Question();
    noQuestion.value = false;

    this.adventure.rootQuestion.questions= [yesQuestion, noQuestion];
  }

}

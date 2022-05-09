import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Adventure } from '../adventure.model';
import { AdventureService } from '../adventure.service';
import { Question } from '../question.model';

@Component({
  selector: 'app-take-adventure',
  templateUrl: './take-adventure.component.html',
  styleUrls: ['./take-adventure.component.css'],
})
export class TakeAdventureComponent implements OnInit {

  adventureId: any;
  adventure: Adventure;
  question: Question;
  selectedValue?:boolean = true;

  constructor(private route:ActivatedRoute, private router:Router, private adventureService:AdventureService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.adventureId = params.get('id');
      this.adventureService.getAdventure(this.adventureId).subscribe(adventure => {
        this.adventure = adventure;
        this.question = adventure.rootQuestion;
      });
    });
  }

  nextQuestion(): void {
    let questionId = this.question.id;
    setTimeout(()=>{
      this.adventureService.getNextQuestion(questionId, this.selectedValue).subscribe(question =>{
        this.question = question;
        if(this.question == null) {
          this.adventureService.saveUserQuestion(questionId,environment.userId,this.adventureId).subscribe(item=>{
            this.selectedValue =null;
            this.router.navigate(['']);
          })
        }
      });
    },500)
    
  }

}

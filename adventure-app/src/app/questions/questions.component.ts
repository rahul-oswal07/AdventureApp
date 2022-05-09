import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../question.model';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {
  @Input() questions: Question[];
  constructor() { }

  ngOnInit(): void {
  }

  addQuestion (question: Question) {

    let yesQuestion = new Question();
    yesQuestion.value = true;
    let noQuestion = new Question();
    noQuestion.value = false;

    question.questions= [yesQuestion, noQuestion];
  }

}

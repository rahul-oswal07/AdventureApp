import { Component, Input, OnInit } from '@angular/core';
import { Question } from '../question.model';

@Component({
  selector: 'app-sub-questions',
  templateUrl: './sub-questions.component.html',
  styleUrls: ['./sub-questions.component.css']
})
export class SubQuestionsComponent implements OnInit {
  @Input() question: Question;
  constructor() { }

  ngOnInit(): void {
  }

}

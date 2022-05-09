import { Question } from "./question.model";

export class Adventure {
  public id: number;
  public name: string;
  public rootQuestionId: number;
  public rootQuestion: Question;
 }
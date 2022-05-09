import { Adventure } from "./adventure.model";
import { Question } from "./question.model";

export class UserAdventure {
    public id: number;
    public name:string
    public adventureId: number;
    public question:Question;
   }
import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from "src/environments/environment";
import { Adventure } from "./adventure.model";
import { Question } from "./question.model";

@Injectable()
export class AdventureService {
    constructor(private http: HttpClient) {}

    public getAllAdventures() {
        return this.http.get<Adventure[]>( environment.apiEndPoint +'/adventures');
      }

      public getAdventure(id:any) {
        return this.http.get<Adventure>( environment.apiEndPoint +'/adventures/'+ id);
      }

      createAdventure(adventure:Adventure) {
        const headers = { 'content-type': 'application/json'}  
        const body=JSON.stringify(adventure);
        return this.http.post<boolean>( environment.apiEndPoint +'/adventures/create', body,{'headers':headers})
      }

      public getNextQuestion(id:any, value:boolean) {
        return this.http.get<Question>( environment.apiEndPoint +'/questions/nextQuestion/' + id +'/'+value );
      }

      public saveUserQuestion(questionId:any, userId:number, adventureId:number) {
        const headers = { 'content-type': 'application/json'}  
        const body=JSON.stringify({
          questionId: questionId, userId: userId, adventureId:adventureId
        });
        return this.http.post<any>( environment.apiEndPoint +'/userAdventures/create',body,{'headers':headers});
      }

}
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { UserAdventure } from "./user-adventure.model";

@Injectable()
export class UserAdventureService {
    constructor(private http: HttpClient) {}

    public getAllUserAdventures(userId: number) {
        return this.http.get<UserAdventure[]>( environment.apiEndPoint +'/useradventures/user/' + userId);
      }

      public getUserAdventure(userAdventureId:number) {
        return this.http.get<UserAdventure>( environment.apiEndPoint +'/useradventures/'+ userAdventureId );
      }

}
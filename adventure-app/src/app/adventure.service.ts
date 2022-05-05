import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from "src/environments/environment";
import { Adventure } from "./adventure.model";

@Injectable()
export class AdventureService {
    constructor(private http: HttpClient) {}

    getAllAdventures() {
        return this.http.get<Adventure[]>( environment.apiEndPoint +'/adventures');
      }

}
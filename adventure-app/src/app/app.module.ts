import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdventuresComponent } from './adventures/adventures.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { CreateAdventureComponent } from './create-adventure/create-adventure.component';
import { QuestionsComponent } from './questions/questions.component';
import { FormsModule } from '@angular/forms';
import { TakeAdventureComponent } from './take-adventure/take-adventure.component';
import { UserAdventureListComponent } from './user-adventure-list/user-adventure-list.component';
import { UserAdventureComponent } from './user-adventure/user-adventure.component';
import { UserAdventureService } from './user-adventure.service';
import { SubQuestionsComponent } from './sub-questions/sub-questions.component';

const appRoutes: Routes = [
  { path: '', component: AdventuresComponent },
  { path: 'create-adventure', component: CreateAdventureComponent },
  { path: 'take-adventure/:id', component: TakeAdventureComponent },
  { path: 'user-adventure-list/:id', component: UserAdventureListComponent },
  { path: 'user-adventure/:id', component: UserAdventureComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    AdventuresComponent,
    CreateAdventureComponent,
    QuestionsComponent,
    TakeAdventureComponent,
    UserAdventureListComponent,
    UserAdventureComponent,
    SubQuestionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UserAdventureService],
  bootstrap: [AppComponent]
})
export class AppModule { }

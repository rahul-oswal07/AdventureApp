import { Component, OnInit } from '@angular/core';
import { Adventure } from '../adventure.model';
import { AdventureService } from '../adventure.service';

@Component({
  selector: 'app-adventures',
  templateUrl: './adventures.component.html',
  styleUrls: ['./adventures.component.css']
})
export class AdventuresComponent implements OnInit {
  adventures: Adventure[];

  constructor(private adventureService: AdventureService) { }

  ngOnInit(): void {
    this.loadAllAdventures();
  }

  loadAllAdventures(): void {
    this.adventureService.getAllAdventures().subscribe((adventures) => {
      this.adventures = adventures;
    });
  }
}

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TakeAdventureComponent } from './take-adventure.component';

describe('TakeAdventureComponent', () => {
  let component: TakeAdventureComponent;
  let fixture: ComponentFixture<TakeAdventureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TakeAdventureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TakeAdventureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

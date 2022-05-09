import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAdventureComponent } from './create-adventure.component';

describe('CreateAdventureComponent', () => {
  let component: CreateAdventureComponent;
  let fixture: ComponentFixture<CreateAdventureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAdventureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAdventureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

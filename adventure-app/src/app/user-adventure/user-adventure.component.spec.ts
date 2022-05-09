import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAdventureComponent } from './user-adventure.component';

describe('UserAdventureComponent', () => {
  let component: UserAdventureComponent;
  let fixture: ComponentFixture<UserAdventureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAdventureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAdventureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

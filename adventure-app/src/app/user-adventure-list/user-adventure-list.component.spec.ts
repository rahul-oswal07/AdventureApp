import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAdventureListComponent } from './user-adventure-list.component';

describe('UserAdventureListComponent', () => {
  let component: UserAdventureListComponent;
  let fixture: ComponentFixture<UserAdventureListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAdventureListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserAdventureListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

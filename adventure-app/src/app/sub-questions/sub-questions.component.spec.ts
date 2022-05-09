import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubQuestionsComponent } from './sub-questions.component';

describe('SubQuestionsComponent', () => {
  let component: SubQuestionsComponent;
  let fixture: ComponentFixture<SubQuestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubQuestionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

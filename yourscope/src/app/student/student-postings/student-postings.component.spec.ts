import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentPostingsComponent } from './student-postings.component';

describe('StudentPostingsComponent', () => {
  let component: StudentPostingsComponent;
  let fixture: ComponentFixture<StudentPostingsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentPostingsComponent]
    });
    fixture = TestBed.createComponent(StudentPostingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

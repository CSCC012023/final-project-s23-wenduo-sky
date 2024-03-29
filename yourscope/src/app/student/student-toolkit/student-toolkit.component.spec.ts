import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentToolkitComponent } from './student-toolkit.component';

describe('StudentToolkitComponent', () => {
  let component: StudentToolkitComponent;
  let fixture: ComponentFixture<StudentToolkitComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentToolkitComponent]
    });
    fixture = TestBed.createComponent(StudentToolkitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

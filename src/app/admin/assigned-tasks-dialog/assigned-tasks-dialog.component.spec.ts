import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignedTasksDialogComponent } from './assigned-tasks-dialog.component';

describe('AssignedTasksDialogComponent', () => {
  let component: AssignedTasksDialogComponent;
  let fixture: ComponentFixture<AssignedTasksDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignedTasksDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignedTasksDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

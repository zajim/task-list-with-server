import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Task } from '../task.model';
import { ValidateTitleNotTaken } from './validators/title-not-taken.validator';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-create-task-dialog',
  templateUrl: './create-task-dialog.component.html',
  styleUrls: ['./create-task-dialog.component.css']
})
export class CreateTaskDialogComponent implements OnInit {

  createTaskForm: FormGroup;

  title = new FormControl('', [Validators.required, ValidateTitleNotTaken.createValidator(this._tasksService)]);
  description = new FormControl('', [Validators.required]);

  constructor(
    private _tasksService: TasksService,
    public dialogRef: MatDialogRef<CreateTaskDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private _task: Task) {}


  ngOnInit() {
    this.createTaskForm = new FormGroup({
      "title": this.title,
      "description": this.description
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    if (this.title.valid && this.description.valid) {
      this._task.title = this.title.value;
      this._task.description = this.description.value;
      this.dialogRef.close(this._task);
    }
  }

  getTitleErrorMessage() {
    return this.title.hasError('required') ? 'You must enter a title' : (this.title.hasError('uniqueTitle') ? 'This title already exists' : '');
  }

  getDescErrorMessage() {
    return this.description.hasError('required') ? 'You must enter a description' : '';
  }

}

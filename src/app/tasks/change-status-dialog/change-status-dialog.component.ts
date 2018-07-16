import { Inject, Component, OnInit } from '@angular/core';

import { FormControl, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Task, TaskStatus, Status } from '../task.model';
import { TasksService } from '../tasks.service';

@Component({
  selector: 'app-change-status-dialog',
  templateUrl: './change-status-dialog.component.html',
  styleUrls: ['./change-status-dialog.component.css']
})
export class ChangeStatusDialogComponent implements OnInit {

  selectedStatus: TaskStatus;

  statuses: Status[] = [];

  constructor(
    private _tasksService: TasksService,
    public dialogRef: MatDialogRef<ChangeStatusDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private _task: Task) { }

  ngOnInit() {
    this.selectedStatus = this._task.status;
    this.statuses = this._tasksService.Statuses;
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    this._task.status = this.selectedStatus;
    this.dialogRef.close(this._task);
  }

}

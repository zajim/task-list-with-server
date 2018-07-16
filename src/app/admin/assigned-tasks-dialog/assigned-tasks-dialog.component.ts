import { Inject, Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Task, TaskStatus } from '../../tasks/task.model'
import { TasksService } from '../../tasks/tasks.service';
import { User } from '../user.model';

@Component({
  selector: 'app-assigned-tasks-dialog',
  templateUrl: './assigned-tasks-dialog.component.html',
  styleUrls: ['./assigned-tasks-dialog.component.css']
})
export class AssignedTasksDialogComponent implements OnInit {

  public dataSource: MatTableDataSource<Task>;

  displayedColumns: string[] = ['title', 'description', 'status'];

  constructor(
    private _tasksService: TasksService,
    public dialogRef: MatDialogRef<AssignedTasksDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private _user: User) { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource<Task>();
    let getAllSub = this._tasksService.getAll({"id": this._user.id}).subscribe((tasks) => {
      this.dataSource.data = tasks;
      getAllSub.unsubscribe();
    });
  }

  displayStatus(status: TaskStatus): string {
    let taskStatus = this._tasksService.Statuses.find((item) => item.value == status);
    if (!taskStatus) {
      return "";
    }
    return taskStatus.name;
  }

}

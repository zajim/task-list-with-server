import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Subscription } from 'rxjs';
import { CreateTaskDialogComponent } from './create-task-dialog/create-task-dialog.component';
import { DeleteTaskDialogComponent } from './delete-task-dialog/delete-task-dialog.component';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';

import { Task, TaskStatus } from './task.model'
import { TasksService } from './tasks.service';
import { AuthService } from '../core/auth.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit, OnDestroy {

  private _subscription: Subscription;

  public dataSource: MatTableDataSource<Task>;
  
  displayedColumns: string[] = ['title', 'description', 'status', 'actions'];

  constructor(private _tasksService: TasksService, public authService: AuthService, public dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource<Task>();
    let conditions: object;
    if (!this.authService.hasRole('admin')) {
      conditions = { id: this.authService.UserId };
    }
    let getAllSub = this._tasksService.getAll(conditions).subscribe((tasks) => {
      this.dataSource.data = tasks;
      this._tasksService.tasks = tasks;
      getAllSub.unsubscribe();
    });

    this._subscription = this._tasksService.tasksObserver.subscribe((tasks: Task[]) => {
      this.dataSource.data = tasks;
    });
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(CreateTaskDialogComponent, {
      width: '250px',
      data: {}
    });

    let dialogSub = dialogRef.afterClosed().subscribe((task: Task) => {
      if (task && task.title && task.description) {
        task.status = TaskStatus.New;
        this._tasksService.addTask(task);
      }
      dialogSub.unsubscribe();
    });
  }

  openDeleteDialog(task: Task): void {
    const dialogRef = this.dialog.open(DeleteTaskDialogComponent, {
      width: '250px',
      data: task
    });

    let dialogSub = dialogRef.afterClosed().subscribe((task: Task) => {
      if (task && task.id) {
        this._tasksService.deleteTask(task);
      }
      dialogSub.unsubscribe();
    });
  }

  openChangeStatusDialog(task: Task): void {
    const dialogRef = this.dialog.open(ChangeStatusDialogComponent, {
      width: '250px',
      data: task
    });

    let dialogSub = dialogRef.afterClosed().subscribe((task: Task) => {
      if (task && task.id) {
        this._tasksService.updateTask(task);
      }
      dialogSub.unsubscribe();
    });
  }

  onTaskChanged(): void {
    this._tasksService.onTaskChanged();
  }

  displayStatus(status: TaskStatus): string {
    let taskStatus = this._tasksService.Statuses.find((item) => item.value == status);
    if (!taskStatus) {
      return "";
    }
    return taskStatus.name;
  }
}

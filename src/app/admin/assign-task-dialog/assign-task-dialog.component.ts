import { Inject, Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TasksService } from '../../tasks/tasks.service';
import { Task } from '../../tasks/task.model';
import { User, UserTask } from '../user.model';

@Component({
  selector: 'app-assign-task-dialog',
  templateUrl: './assign-task-dialog.component.html',
  styleUrls: ['./assign-task-dialog.component.css']
})
export class AssignTaskDialogComponent implements OnInit {

  tasks: Task[];
  selectedTaskId: string;

  constructor(
    private _tasksService: TasksService,
    public dialogRef: MatDialogRef<AssignTaskDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private _user: User) { }

  ngOnInit() {
    let getAllSub = this._tasksService.getAll().subscribe((tasks) => {
      this.tasks = tasks;
      getAllSub.unsubscribe();
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    let userTask: UserTask = new UserTask();
    userTask.taskId = this.selectedTaskId;
    userTask.userId = this._user.id;
    this.dialogRef.close(userTask);
  }

}

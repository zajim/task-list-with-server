import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { User, UserTask } from './user.model';
import { AdminService } from './admin.service';
import { AssignTaskDialogComponent } from './assign-task-dialog/assign-task-dialog.component';
import { AssignedTasksDialogComponent } from './assigned-tasks-dialog/assigned-tasks-dialog.component';
import { MatDialog, MatDialogRef } from '@angular/material';
import { AuthService } from '../core/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  public dataSource: MatTableDataSource<User>;

  displayedColumns: string[] = ['id', 'userName', 'actions'];

  constructor(
    private _adminService: AdminService,
    private _authService: AuthService,
    private _router: Router,
    public dialog: MatDialog) { }

  ngOnInit() {
    if (!this._authService.hasRole('admin')) {
      this._router.navigate(['/tasks']);
    }
    this.dataSource = new MatTableDataSource<User>();
    let getAllSub = this._adminService.getAll().subscribe((users) => {
      this.dataSource.data = users;
      getAllSub.unsubscribe();
    }, (error) => {
      getAllSub.unsubscribe();
    });
  }

  openAssignTaskDialog(user: User): void {
    const dialogRef = this.dialog.open(AssignTaskDialogComponent, {
      width: '250px',
      data: user
    });

    let dialogSub = dialogRef.afterClosed().subscribe((userTask: UserTask) => {
      if (userTask && userTask.userId && userTask.taskId) {
        this._adminService.assignTask(userTask).subscribe((result) => {
          if (result) {
            console.log('assigned');
          } else {
            console.log('task already assigned');
          }
          dialogSub.unsubscribe();
        });
      }
    });
  }

  openAssignedTasksDialog(user: User): void {
    const dialogRef = this.dialog.open(AssignedTasksDialogComponent, {
      width: '600px',
      data: user
    });
  }

}

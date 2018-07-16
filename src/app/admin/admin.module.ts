import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { TasksService } from '../tasks/tasks.service';

import { AdminComponent } from './admin.component';
import { AdminService } from './admin.service';
import { AssignTaskDialogComponent } from './assign-task-dialog/assign-task-dialog.component';
import { AssignedTasksDialogComponent } from './assigned-tasks-dialog/assigned-tasks-dialog.component';

@NgModule({
  declarations: [
    AdminComponent,
    AssignTaskDialogComponent,
    AssignedTasksDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatTableModule,
    MatIconModule,
    MatSelectModule,
    MatButtonModule
  ],
  exports: [AdminComponent],
  providers: [AdminService,TasksService],
  entryComponents: [AdminComponent,AssignTaskDialogComponent,AssignedTasksDialogComponent]
})

export class AdminModule { }
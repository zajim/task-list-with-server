import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';

import { TasksComponent } from './tasks.component';
import { TasksService } from './tasks.service';
import { CreateTaskDialogComponent } from './create-task-dialog/create-task-dialog.component';
import { DeleteTaskDialogComponent } from './delete-task-dialog/delete-task-dialog.component';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';

@NgModule({
  declarations: [
    TasksComponent,
    CreateTaskDialogComponent,
    DeleteTaskDialogComponent,
    ChangeStatusDialogComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatCheckboxModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule
  ],
  exports: [TasksComponent],
  providers: [TasksService],
  entryComponents: [
    TasksComponent,
    CreateTaskDialogComponent,
    DeleteTaskDialogComponent,
    ChangeStatusDialogComponent
  ]
})

export class TasksModule { }
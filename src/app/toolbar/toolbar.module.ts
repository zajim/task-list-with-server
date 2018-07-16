import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { MatToolbarModule, MatToolbarRow } from '@angular/material/toolbar';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';

import { ToolbarComponent } from './toolbar.component';

@NgModule({
  declarations: [
    ToolbarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule,
    MatChipsModule,
    MatIconModule,
    MatListModule
  ],
  exports: [
    ToolbarComponent
  ],
  providers: []
})

export class ToolbarModule { }
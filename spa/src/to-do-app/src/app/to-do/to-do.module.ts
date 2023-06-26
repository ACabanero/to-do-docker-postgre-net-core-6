import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoListComponent } from './to-do-list/to-do-list.component';
import { ToDoCreateComponent } from './to-do-create/to-do-create.component';



@NgModule({
  declarations: [
    ToDoListComponent,
    ToDoCreateComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ToDoModule { }

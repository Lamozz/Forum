import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageAddComponent } from './message-add.component';
import { MaterialModule } from '../shared/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    MessageAddComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    MessageAddComponent
  ]
})
export class MessageAddModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserViewComponent } from './user-view.component';
import { UserViewRoutingModule } from './user-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    UserViewComponent
  ],
  imports: [
    CommonModule, 
    UserViewRoutingModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    UserViewComponent
  ]
})
export class UserViewModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from '../home/home-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { ThemeViewComponent } from './theme-view.component';
import { MessageAddModule } from '../message-add/message-add.module';



@NgModule({
  declarations: [
    ThemeViewComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HomeRoutingModule,
    MessageAddModule
  ],
  exports: [
    ThemeViewComponent
  ]
})
export class ThemeViewModule { }

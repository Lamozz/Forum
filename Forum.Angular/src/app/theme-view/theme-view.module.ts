import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from '../home/home-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { ThemeViewComponent } from './theme-view.component';



@NgModule({
  declarations: [
    ThemeViewComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HomeRoutingModule,
  ],
  exports: [
    ThemeViewComponent
  ]
})
export class ThemeViewModule { }

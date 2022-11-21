import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionViewComponent } from './section-view.component';
import { MaterialModule } from '../shared/material/material.module';
import { HomeRoutingModule } from '../home/home-routing.module';
import { ThemeViewModule } from '../theme-view/theme-view.module';



@NgModule({
  declarations: [
    SectionViewComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HomeRoutingModule,
    ThemeViewModule
  ],
  exports: [
    SectionViewComponent
  ]
})
export class SectionViewModule { }

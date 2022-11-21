import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryViewComponent } from './category-view.component';
import { MaterialModule } from '../shared/material/material.module';
import { SectionViewModule } from '../section-view/section-view.module';
import { HomeRoutingModule } from '../home/home-routing.module';



@NgModule({
  declarations: [
    CategoryViewComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SectionViewModule,
    HomeRoutingModule
  ],
  exports: [
    CategoryViewComponent
  ]
})
export class CategoryViewModule { }

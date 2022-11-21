import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';
import { HomeAuthResolver } from './home-auth-resolver.service';
import { SharedModule } from '../shared';
import { HomeRoutingModule } from './home-routing.module';
import { MaterialModule } from '../shared/material/material.module';
import { CategoryViewModule } from '../category-view/category-view.module';

@NgModule({
  imports: [
    SharedModule,
    HomeRoutingModule,
    MaterialModule,
    CategoryViewModule
  ],
  declarations: [
    HomeComponent
  ],
  providers: [
    HomeAuthResolver
  ]
})
export class HomeModule {}

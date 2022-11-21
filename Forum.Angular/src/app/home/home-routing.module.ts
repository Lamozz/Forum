import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { HomeAuthResolver } from './home-auth-resolver.service';
import { CategoryViewComponent } from '../category-view/category-view.component';
import { SectionViewComponent } from '../section-view/section-view.component';
import { ThemeViewComponent } from '../theme-view/theme-view.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    resolve: {
      isAuthenticated: HomeAuthResolver
    }
  },
  {
    path: 'category/:categoryId',
    component: CategoryViewComponent
  },
  {
    path: 'category/:categoryId/section/:sectionId',
    component: SectionViewComponent
  },
  {
    path: 'category/:categoryId/section/:sectionId/theme/:themeId',
    component: ThemeViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule {}

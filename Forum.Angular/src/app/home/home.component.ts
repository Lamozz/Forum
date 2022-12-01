import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';

import { ArticleListConfig, TagsService, UserService } from '../core';
import { Category } from '../_models/category/category';
import { PaginateRequest } from '../_models/pagination/paginate-request';
import { PaginateResult } from '../_models/pagination/paginate-result';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['id', 'title'];
  public categories: Category[];

  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private tagsService: TagsService,
    private userService: UserService
  ) {}

  isAuthenticated: boolean;
  listConfig: ArticleListConfig = {
    type: 'all',
    filters: {}
  };
  tags: Array<string> = [];
  tagsLoaded = false;

  ngOnInit() {
    // this.userService.isAuthenticated.subscribe(
    //   (authenticated) => {
    //     this.isAuthenticated = authenticated;

    //     // set the article list accordingly
    //     if (authenticated) {
    //       this.setListTo('feed');
    //     } else {
    //       this.setListTo('all');
    //     }
    //   }
    // );

    // this.tagsService.getAll()
    // .subscribe(tags => {
    //   this.tags = tags;
    //   this.tagsLoaded = true;
    // });
  }
  setListTo(type: string = '', filters: Object = {}) {
    // If feed is requested but user is not authenticated, redirect to login
    if (type === 'feed' && !this.isAuthenticated) {
      this.router.navigateByUrl('/login');
      return;
    }

    // Otherwise, set the list object
    this.listConfig = {type: type, filters: filters};
  }

  //paginator
  public paginateResult: PaginateResult<Category>;

  @ViewChild(MatPaginator, {static: false}) 
  paginator: MatPaginator | undefined;

  @ViewChild(MatSort, { static: false}) 
  sort: MatSort;

  sortDirection: string = 'asc';
  filter: string = '';
  filterPath: string = '';

  ngAfterViewInit() {
    this.setCategories();
  }

  changeTable() {
    console.log(this.sortDirection);
    this.setCategories();
  }

  public setCategories() {
    let filters = {
      path: this.filterPath,
      value: this.filter
    }
    let paginateRequest = new PaginateRequest(this.paginator!, this.sort, filters);
    this.categoryService.getPagedCategories(paginateRequest).subscribe((result) => {
      this.paginateResult = result;
      this.categories = result.items;
      console.log(result)
    });
  }
}

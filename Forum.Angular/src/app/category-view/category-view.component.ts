import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Section } from '../_models/section/section';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-category-view',
  templateUrl: './category-view.component.html',
  styleUrls: ['./category-view.component.css']
})
export class CategoryViewComponent implements OnInit {

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.route.snapshot.params['categoryId'];
    console.log(id);
    this.categoryService.getCategory(id).subscribe((result) => {
      this.sections = result.sections;
      console.log(result.sections);
    });
  }

  displayedColumns: string[] = ['id', 'title', 'description'];
  public sections: Section[];

}

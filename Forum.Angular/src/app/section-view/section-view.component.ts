import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Theme } from '../_models/theme/theme';
import { User } from '../_models/user/user';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-section-view',
  templateUrl: './section-view.component.html',
  styleUrls: ['./section-view.component.css']
})
export class SectionViewComponent implements OnInit {

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let categoryid: number = this.route.snapshot.params['categoryId'];
    let sectionid: number = this.route.snapshot.params['sectionId'];
    this.categoryService.getCategory(categoryid).subscribe((result) => {
      
      let section = result.sections.find((Section) => {return Section.id.toString() === sectionid.toString();});
      this.themes = section.themes;
      console.log(this.themes);
    });
    this.dataSource = new MatTableDataSource(this.themes);
  }

  displayedColumns: string[] = ['id', 'title', 'description', 'creatingTime', 'author'];
  public themes: Theme[];
  public user: User;
  public dataSource;

}

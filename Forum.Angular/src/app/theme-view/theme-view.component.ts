import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user/user';
import { Message } from '../_models/message/message';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-theme-view',
  templateUrl: './theme-view.component.html',
  styleUrls: ['./theme-view.component.css']
})
export class ThemeViewComponent implements OnInit {

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let categoryid: number = this.route.snapshot.params['categoryId'];
    let sectionid: number = this.route.snapshot.params['sectionId'];
    let themeid: number = this.route.snapshot.params['themeId']
    this.categoryService.getCategory(categoryid).subscribe((result) => {
      

      let section = result.sections.find((Section) => {return Section.id.toString() === sectionid.toString();});
      let theme = section.themes.find((Theme) => {return Theme.id.toString() === themeid.toString();});
      this.messages = theme.messages;

    });
    this.dataSource = new MatTableDataSource(this.messages);
  }

  displayedColumns: string[] = ['id', 'text', 'creatingTime', 'author'];
  public messages: Message[];
  public user: User[];
  public dataSource;

}

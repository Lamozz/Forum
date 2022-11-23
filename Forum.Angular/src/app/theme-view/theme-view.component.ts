import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user/user';
import { Message } from '../_models/message/message';
import { CategoryService } from '../_services/category.service';
import { MatDialog } from '@angular/material/dialog';
import { MessageAddComponent } from '../message-add/message-add.component';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-theme-view',
  templateUrl: './theme-view.component.html',
  styleUrls: ['./theme-view.component.css']
})
export class ThemeViewComponent implements OnInit {

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    let categoryid: number = this.route.snapshot.params['categoryId'];
    let sectionid: number = this.route.snapshot.params['sectionId'];
    this.themeId = this.route.snapshot.params['themeId']
    this.categoryService.getCategory(categoryid).subscribe((result) => {
      

      let section = result.sections.find((Section) => {return Section.id.toString() === sectionid.toString();});
      let theme = section.themes.find((Theme) => {return Theme.id.toString() === this.themeId.toString();});
      this.messages = theme.messages;

    });
    this.dataSource = new MatTableDataSource(this.messages);
    this.messageForCreate = {
      authorId: this.userService.getCurrentUser(),
      themeId: this.themeId
    }
  }

  displayedColumns: string[] = ['id', 'text', 'creatingTime', 'author'];
  public messages: Message[];
  public user: User[];
  public dataSource;
  public themeId: number;

  public currentUser: User;
  public messageForCreate;

  createMessage(themeId: number) {
    
  }

}

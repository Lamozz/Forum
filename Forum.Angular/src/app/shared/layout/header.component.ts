import { Component, OnInit } from '@angular/core';
import { User, UserService } from '../../core';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
  constructor(
    private userService: UserService,
    public accountService: AccountService
  ) {}

  currentUser: User;

  ngOnInit() {
    this.userService.currentUser.subscribe(
      (userData) => {
        this.currentUser = userData;
      }
    );
  }
}

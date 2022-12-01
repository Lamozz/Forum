import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user/user';
import { AvatarService } from '../_services/avatar.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private avatarService: AvatarService,
    private sanitizer: DomSanitizer
  ) { }

  user: User;
  public image: File | undefined;
  public imageUrl: SafeUrl | undefined;

  ngOnInit(): void {
    let userId = this.route.snapshot.params['userId'];
    this.userService.getUser(userId).subscribe({
      next: (userResult) => {
        this.user = userResult;
        console.log('user');
        console.log(this.user);

        this.avatarService.getImage(userId).subscribe({
          next: (response) => {
            const blob = new Blob([response], { type: "image/jpeg" });
            const objectURL = URL.createObjectURL(blob);
            const img = this.sanitizer.bypassSecurityTrustUrl(objectURL);
            this.imageUrl = img;
          }
        });
      }
    })
  }

  public onImageChanged(event: any) {
    let file: File = event.target.files[0];
    
    if (file.type != 'image/jpeg') {
      this.imageForm.controls['image'].reset();
    }
    this.image = file;
  }

  imageForm = new FormGroup({
    image: new FormControl('', [Validators.required])
  });

  public ChangeAvatar() {
    let formData = new FormData();
    formData.append('avatar', this.image!, this.image!.name);

      if (this.imageUrl === undefined) {
        this.avatarService.createImage(formData, this.user.id).subscribe();
      } else {
        this.avatarService.updateImage(formData, this.user.id).subscribe();
      }
  }

}

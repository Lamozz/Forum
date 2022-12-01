import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Message } from '../_models/message/message';
import { MessageService } from '../_services/message.service';
@Component({
  selector: 'app-message-add',
  templateUrl: './message-add.component.html',
  styleUrls: ['./message-add.component.css']
})
export class MessageAddComponent implements OnInit {

  public readonly ACTION_CANCEL: string = "CANCELED";
  public readonly ACTION_CREATE: string = "CREATED";

  public title: string = "Add new message";

  @Input()
  public message: Message;
  public messageForm: FormGroup;

  constructor(
    private messageService: MessageService
  ) { 
    

    
  }

  ngOnInit(): void {
    console.log("Dialog");
    
    this.messageForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      text: new FormControl('', [Validators.required]),
      authorId: new FormControl(this.message.authorId, [Validators.required]),
      themeId: new FormControl(this.message.themeId, [Validators.required]),
      creationDate: new FormControl(Date.now, [])
    });
  }

  public createMessage() {
    this.message = this.messageForm.value;
    this.messageService.createMessage(this.message).subscribe();
  }
}

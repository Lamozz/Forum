import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Message } from '../_models/message/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getMessage(id: number): Observable<Message> {
    return this.httpClient.get<Message>(`${environment.api_url}/api/messages/${id}`);
  }

  public createMessage(message: Message): Observable<Message> {
    return this.httpClient.post<Message>(`${environment.api_url}/api/messages`, message);
  }

  public updateMessage(message: Message): Observable<Message> {
    return this.httpClient.put<Message>(`${environment.api_url}/api/messages/${message.id}`, message);
  }

  public deleteMessage(id: number) {
    return this.httpClient.delete(`${environment.api_url}/api/messages/${id}`);
  }
}

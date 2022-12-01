import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AvatarService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getImage(userId: number) {
    return this.httpClient.get(`${environment.api_url}/api/avatar/${userId}`, {responseType: 'blob'});
  }

  public createImage(fileForm: FormData, userId: number): Observable<any> {
    return this.httpClient.post(`${environment.api_url}/api/avatar/${userId}`, fileForm);
  }

  public updateImage(fileForm: FormData, userId: number): Observable<any> {
    return this.httpClient.put(`${environment.api_url}/api/avatar/${userId}`, fileForm);
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../_models/user/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCurrentUser(): number {
    const token = localStorage.getItem('accessToken');

    if (token == null) {
      return null;
    }

    let decodedJWT = JSON.parse(window.atob(token.split('.')[1]));

    let userId = decodedJWT['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

    return userId;
  }

  public getUser(id: number): Observable<User> {
    return this.httpClient.get<User>(`${environment.api_url}/api/user/${id}`);
  }

  public updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(`${environment.api_url}/api/user/${user.id}`, user);
  }
}
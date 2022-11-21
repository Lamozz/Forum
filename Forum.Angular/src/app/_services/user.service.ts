import { User } from '../_models/user/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>("/api/users");
  }

  public getUser(id: number): Observable<User> {
    return this.httpClient.get<User>(`/api/users/${id}`);
  }

  public createUser(user: User): Observable<User> {
    return this.httpClient.post<User>("/api/users", user);
  }

  public updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(`/api/users/${user.id}`, user);
  }

  public deleteUser(id: number) {
    return this.httpClient.delete(`/api/users/${id}`);
  }

}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { JwtToken } from '../_models/account/jwt-token';
import { UserRegister } from '../_models/user/user-register';
import { UserLogin } from '../_models/user/user-login';
import { Router } from '@angular/router'
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    private httpClient: HttpClient,
    private _router: Router
  ) { }

  public isLoggedIn(): boolean {
    let token = localStorage.getItem("accessToken");
    return token ? true : false;
  }

  public login(userLogin: UserLogin): Observable<JwtToken> {
    return this.httpClient.post<JwtToken>(`${environment.api_url}/api/account/login`, userLogin).pipe(
      tap((token: JwtToken) => {
        console.log(token.accessToken);
        localStorage.setItem("accessToken", token.accessToken);
      })
    );
  }

  public register(userRegister: UserRegister): Observable<UserRegister> {
    return this.httpClient.post<UserRegister>(`${environment.api_url}/api/account/register`, userRegister);
  }

  public SignOut(){
    let cleartoken = localStorage.removeItem("accessToken");
    this._router.navigate(['/']);
    return cleartoken;
  }
}
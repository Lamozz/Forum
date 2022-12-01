import { Theme } from '../_models/theme/theme';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getThemes(): Observable<Theme[]> {
    return this.httpClient.get<Theme[]>(`${environment.api_url}/api/themes`);
  }

  public getTheme(id: number): Observable<Theme> {
    return this.httpClient.get<Theme>(`${environment.api_url}/api/themes/${id}`);
  }

  public createTheme(theme: Theme): Observable<Theme> {
    return this.httpClient.post<Theme>(`${environment.api_url}/api/themes`, theme);
  }

  public updateTheme(theme: Theme): Observable<Theme> {
    return this.httpClient.put<Theme>(`${environment.api_url}/api/themes/${theme.id}`, theme);
  }

  public deleteTheme(id: number) {
    return this.httpClient.delete(`${environment.api_url}/api/themes/${id}`);
  }

}
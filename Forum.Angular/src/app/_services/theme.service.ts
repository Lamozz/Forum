import { Theme } from '../_models/theme/theme';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getThemes(): Observable<Theme[]> {
    return this.httpClient.get<Theme[]>("/api/themes");
  }

  public getTheme(id: number): Observable<Theme> {
    return this.httpClient.get<Theme>(`/api/themes/${id}`);
  }

  public createTheme(theme: Theme): Observable<Theme> {
    return this.httpClient.post<Theme>("/api/themes", theme);
  }

  public updateTheme(theme: Theme): Observable<Theme> {
    return this.httpClient.put<Theme>(`/api/themes/${theme.id}`, theme);
  }

  public deleteTheme(id: number) {
    return this.httpClient.delete(`/api/themes/${id}`);
  }

}
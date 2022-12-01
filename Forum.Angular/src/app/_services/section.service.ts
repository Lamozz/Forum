import { Section } from '../_models/section/section';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getSections(): Observable<Section[]> {
    return this.httpClient.get<Section[]>(`${environment.api_url}/api/sections`);
  }

  public getSection(id: number): Observable<Section> {
    return this.httpClient.get<Section>(`${environment.api_url}/api/sections/${id}`);
  }

  public createSection(section: Section): Observable<Section> {
    return this.httpClient.post<Section>(`${environment.api_url}/api/sections`, section);
  }

  public updateSection(section: Section): Observable<Section> {
    return this.httpClient.put<Section>(`${environment.api_url}/api/sections/${section.id}`, section);
  }

  public deleteSection(id: number) {
    return this.httpClient.delete(`${environment.api_url}/api/sections/${id}`);
  }

}
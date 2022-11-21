import { Section } from '../_models/section/section';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getSections(): Observable<Section[]> {
    return this.httpClient.get<Section[]>("/api/sections");
  }

  public getSection(id: number): Observable<Section> {
    return this.httpClient.get<Section>(`/api/sections/${id}`);
  }

  public createSection(section: Section): Observable<Section> {
    return this.httpClient.post<Section>("/api/sections", section);
  }

  public updateSection(section: Section): Observable<Section> {
    return this.httpClient.put<Section>(`/api/sections/${section.id}`, section);
  }

  public deleteSection(id: number) {
    return this.httpClient.delete(`/api/sections/${id}`);
  }

}
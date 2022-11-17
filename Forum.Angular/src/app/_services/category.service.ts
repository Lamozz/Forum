import { Category } from '../_models/category/category';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>("/api/categories");
  }

  public getCategory(id: number): Observable<Category> {
    return this.httpClient.get<Category>(`/api/categories/${id}`);
  }

  public createCategory(category: Category): Observable<Category> {
    return this.httpClient.post<Category>("/api/categories", category);
  }

  public updateCategory(category: Category): Observable<Category> {
    return this.httpClient.put<Category>(`/api/categories/${category.id}`, category);
  }

  public deleteCategory(id: number) {
    return this.httpClient.delete(`/api/categories/${id}`);
  }

}
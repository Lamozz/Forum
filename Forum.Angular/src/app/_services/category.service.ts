import { Category } from '../_models/category/category';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginateRequest } from '../_models/pagination/paginate-request';
import { PaginateResult } from '../_models/pagination/paginate-result';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(`${environment.api_url}/api/categories`);
  }

  public getPagedCategories(paginationRequest: PaginateRequest): Observable<PaginateResult<Category>> {
    return this.httpClient.post<PaginateResult<Category>>(`${environment.api_url}/api/categories/paginate`, paginationRequest);
  }

  public getCategory(id: number): Observable<Category> {
    return this.httpClient.get<Category>(`${environment.api_url}/api/categories/${id}`);
  }

  public createCategory(category: Category): Observable<Category> {
    return this.httpClient.post<Category>(`${environment.api_url}/api/categories`, category);
  }

  public updateCategory(category: Category): Observable<Category> {
    return this.httpClient.put<Category>(`${environment.api_url}/api/categories/${category.id}`, category);
  }

  public deleteCategory(id: number) {
    return this.httpClient.delete(`${environment.api_url}/api/categories/${id}`);
  }

}
import { Injectable } from '@angular/core';
import { CategoryDto } from '../../models/categoryDto';
import { Category } from '../../models/category';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = `${environment.apiBase}/api/categories`;

  constructor(private http: HttpClient) { }

  addCategory(category: CategoryDto): Observable<Category> {
    return this.http.post<Category>(this.apiUrl, category);
  }

  getAllCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`);
  }
}

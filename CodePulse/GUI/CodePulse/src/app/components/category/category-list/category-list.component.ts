import { Component, OnInit } from '@angular/core';
import { Category } from '../../../models/category';

import { CategoryService } from '../../../services/category/category.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {

  categories$?: Observable<Category[]>;

  constructor(private categoryService: CategoryService){

  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategory();
  }
}

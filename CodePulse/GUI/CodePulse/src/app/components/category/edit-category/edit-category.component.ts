import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../../../services/category/category.service';
import { Category } from '../../../models/category';

@Component({
  selector: 'app-edit-category',
  standalone: false,
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css'
})

export class EditCategoryComponent implements OnInit, OnDestroy{

  id: string | null = null;
  category?: Category;

  private routerSubscription?: Subscription;

  constructor(private router: ActivatedRoute, private categoryService: CategoryService){

  }

  onSubmit(){
    console.log(this.category);
  }

  ngOnInit(): void {
    this.routerSubscription = this.router.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        console.log("Category ID:", this.id);
        if(this.id){
          this.categoryService.getCategoryById(this.id).subscribe({
            next: (response) => {
              this.category = response;
            }
          })
        }
      }
    })
  }


  ngOnDestroy(): void {
    this.routerSubscription?.unsubscribe();
  }



}

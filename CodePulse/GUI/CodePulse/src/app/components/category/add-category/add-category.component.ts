import { Component, OnDestroy } from '@angular/core';
import { CategoryDto } from '../../../models/categoryDto';
import { CategoryService } from '../../../services/category/category.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  standalone: false,
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnDestroy {

  category: CategoryDto;
  private addCategorySubscribe?: Subscription;

  constructor(private categoryService: CategoryService, private router: Router){
    this.category = {
      name: '',
      url: ''
    }
  }



  onSubmit(){
    console.log(this.category);

    this.addCategorySubscribe = this.categoryService.addCategory(this.category).subscribe(
      {
        next: (response) => {
          this.router.navigateByUrl('/admin/categories/list');
        },
      }
    );
  }

  ngOnDestroy(): void {
    this.addCategorySubscribe?.unsubscribe();
  }

}

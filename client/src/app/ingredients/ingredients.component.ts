import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../_models/category';
import { Recipe } from '../_models/recipe';
import { CategoriesService } from '../_services/categories.service';
import { RecipesService } from '../_services/recipes.service';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent implements OnInit {
  recipe: Recipe;
  category: Category;

  constructor(private route:ActivatedRoute,private recipeService: RecipesService,private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.loadRecipe();
    this.loadCategory();
  }

 
  loadRecipe(){
    this.recipeService.getRecipe(this.route.snapshot.paramMap.get('recipeId')as unknown as number).subscribe(recipe=>{
      this.recipe=recipe;

    })
  }

  loadCategory(){
    this.categoryService.getCategory(this.route.snapshot.paramMap.get('categoryId')as unknown as number).subscribe(category=>{
      this.category=category;
    })

  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { Category } from '../_models/category';
import { Recipe } from '../_models/recipe';
import { CategoriesService } from '../_services/categories.service';
import { RecipesService } from '../_services/recipes.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  recipes: Recipe[];
  category: Category;
  // recipe:Recipe;


  constructor(private recipeService: RecipesService, private route: ActivatedRoute, private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.loadCategory();
    this.loadRecipes();
  }

  loadCategory(){
    let id = this.route.snapshot.paramMap.get('categoryId') as unknown as number;
    this.categoryService.getCategory(id).subscribe(category=>{
      this.category=category;
    })
  }
  
  loadRecipes() {
    let id = this.route.snapshot.paramMap.get('categoryId') as unknown as number;
    this.recipeService.getRecipesByCategory(id).subscribe(recipes => {
      this.recipes = recipes;
    })
  }
}



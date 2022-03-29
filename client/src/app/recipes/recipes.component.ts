import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from '../_models/recipe';
import { RecipesService } from '../_services/recipes.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.css']
})
export class RecipesComponent implements OnInit {
  recipes: Recipe[];


  constructor(private recipeService: RecipesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadRecipes();
  }

 
  loadRecipes(){
    this.recipeService.getRecipes().subscribe(recipes => {
      this.recipes=recipes;
    })
      
  }
  
  }



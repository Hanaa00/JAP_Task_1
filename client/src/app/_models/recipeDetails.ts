import { Ingredient } from "../_models/ingredient";
import { Recipe } from "../_models/recipe";

export interface RecipeDetail{
  ingredientId: number;
  ingredient: Ingredient[];
  recipeId: number;
  recipe: Recipe[];
  quantity:number;

}
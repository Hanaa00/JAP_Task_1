import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Recipe } from '../_models/recipe';
import {Category} from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  baseUrl=environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRecipes(){
    return this.http.get<Recipe[]>(this.baseUrl+'recipes');
  }

  getRecipe(id:number){
    return this.http.get<Recipe>(this.baseUrl+'recipes/'+ id)
  }

  getRecipeByCategoryId(id:number){
    return this.http.get<Recipe[]>(this.baseUrl+'categories/'+id);
  }
}

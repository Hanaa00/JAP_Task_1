import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryDetailComponent } from './categories/category-detail/category-detail.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { RecipeCardComponent } from './recipes/recipe-card/recipe-card.component';
import { RecipesComponent } from './recipes/recipes.component';
import { AuthGuard } from './_guards/auth.guard';
import { IngredientsComponent } from './ingredients/ingredients.component';


const routes: Routes = [
  {path:'',component:HomeComponent},
  {
    path:'',
    runGuardsAndResolvers:'always',
    canActivate:[AuthGuard],
    children:[
      {path:'members',component:MemberListComponent,canActivate:[AuthGuard]},
      {path:'categories',component:CategoryListComponent,canActivate:[AuthGuard]},
      {path:'categories/:categoryId',component:CategoryDetailComponent},
      {path:'categories/:categoryId/:recipeId',component:IngredientsComponent},
      {path:'recipes',component:RecipesComponent},

      
      {path:'lists',component:ListsComponent},
      {path:'messages',component:MessagesComponent},
    ]
  },
 
  {path:'**',component:HomeComponent,pathMatch:'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Category } from './category';
import { Photo } from './photo';


export interface Recipe{

    id:number;
    recipeName:string;
    recipePhoto:string;
    description:string;
    photos: Photo[];
    categories:Category[];
}
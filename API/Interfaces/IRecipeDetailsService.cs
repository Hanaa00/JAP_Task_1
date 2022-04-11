using API.Entities;

namespace API.Interfaces
{
    public interface IRecipeDetailsService
    {
        Task<IEnumerable<RecipeDetails>> GetRecipeDetails();

         Task<IEnumerable<RecipeDetails>> GetIngredientByRecipe(int recipeId);



    }
}
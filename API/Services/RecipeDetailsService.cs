using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RecipeDetailsService : IRecipeDetailsService
    {
        private readonly DataContext _context;
        public RecipeDetailsService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeDetails>> GetRecipeDetails()
        {
            return await _context.RecipeDetails.ToListAsync();
        }

        public async Task<IEnumerable<RecipeDetails>> GetIngredientByRecipe(int recipeId)
        {
           return await _context.RecipeDetails.Include(x=> x.Ingredient).Where(x=> x.RecipeId==recipeId).ToListAsync();
        }
    }
}
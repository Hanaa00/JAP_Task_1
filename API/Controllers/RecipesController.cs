using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class RecipesController : BaseApiController
    {
        private readonly DataContext _context;
        public RecipesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return Ok(await _context.Recipe.ToListAsync());
        }

        [HttpGet("{RecipeId}")]
        public async Task<IActionResult> GetRecipe(int RecipeId)
        {
            var recipe = await _context.Recipe
                .Include(x => x.Category)
                .Include(x => x.RecipeDetailsList)
                    .ThenInclude(x => x.Ingredient)
                .FirstOrDefaultAsync(x=> x.Id == RecipeId);

            return Ok(recipe);
        }

        [HttpGet]
        [Route ("getrecipebycategory/{categoryId}")]
        public async Task<List<Recipe>> GetRecipeByCategory(int categoryId) {
              return await _context.Recipe.Where(u => u.CategoryId == categoryId).ToListAsync();
        }
        // public async Task<List<Recipe>> (int id)
        // {
        //     // //var list = await _context.Recipe.Where(x=> x.CategoryId == id);
        //     // var list = _context.Recipe.Where(x=>x.CategoryId == id);
        //     // var items = await list.ToListAsync<Recipe>;
        //     // // var items = list.MapTo
        //     // return Ok(items);
        //     return await _context.Recipe.Where(x=> x.CategoryId == id).ToListAsync();

        // }

        //EXCEPTION MIDDLEWARE



    }
}
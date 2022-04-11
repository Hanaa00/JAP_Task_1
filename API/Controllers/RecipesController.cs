using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class RecipesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IRecipeService _recipeService;
        public RecipesController(DataContext context, IRecipeService recipeService)
        {
            _recipeService = recipeService;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeService.GetRecipes();

            return Ok(recipes);

            // return Ok(await _context.Recipe.ToListAsync());
        }

        [HttpGet("{RecipeId}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int recipeId)
        {
           
               if (recipeId < 1)
                return BadRequest();
            
            return await _context.Recipe.FindAsync(recipeId);

            // .Include(x => x.Category)
            // .Include(x => x.RecipeDetailsList)
            //     .ThenInclude(x => x.Ingredient)
            // .FirstOrDefaultAsync(x=> x.Id == RecipeId);

            // // return Ok(recipe);

        }

        [HttpGet]
        [Route("getrecipebycategory/{categoryId}")]
        public async Task<List<Recipe>> GetRecipeByCategory(int categoryId)
        {
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
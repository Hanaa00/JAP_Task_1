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
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipe.ToListAsync();
            
        }

        [HttpGet("{RecipeId}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int RecipeId)
        {
            return await _context.Recipe.FindAsync(RecipeId);
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




    }
}
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

        public async Task<IList<Recipe>> GetRecipeById(int id)
        {
            var list = _context.Recipe.Where(x=> x.CategoryId==id).ToListAsync();
            return await list;


        }




    }
}
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RecipeDetailsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IRecipeDetailsService _recipedetailsService;
        public RecipeDetailsController(DataContext context, IRecipeDetailsService recipedetailsService)
        {
            _recipedetailsService = recipedetailsService;
            _context = context;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RecipeDetails>>> GetRecipeDetails()
        {
            var recipedetails = await _recipedetailsService.GetRecipeDetails();

            return Ok(recipedetails);

            // return Ok(await _context.Recipe.ToListAsync());
        }

        [HttpGet]
        [Route("getingredientbyrecipe/{recipeId}")]
        public async Task<IEnumerable<RecipeDetails>> GetIngredientByRecipe(int recipeId)
        {
             return await _recipedetailsService.GetIngredientByRecipe(recipeId);

        
        }
    }
}
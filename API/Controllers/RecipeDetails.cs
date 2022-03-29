using API.Data;

namespace API.Controllers
{
    public class RecipeDetails : BaseApiController
    {
        private readonly DataContext _context;
        public RecipeDetails(DataContext context)
        {
            _context = context;

        }

        
    }
}
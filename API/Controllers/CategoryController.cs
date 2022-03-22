using API.Data;

namespace API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;

        }

       
    }
}
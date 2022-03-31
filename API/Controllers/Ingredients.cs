using API.Data;

namespace API.Controllers
{
    public class Ingredients : BaseApiController
    {
        private readonly DataContext _context;
        public Ingredients(DataContext context)
        {
            _context = context;
        }

       
        



    }
}
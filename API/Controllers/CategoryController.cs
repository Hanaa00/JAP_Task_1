using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<AppUser>> GetCategory(int CategoryId)
        {
            return await _context.Users.FindAsync(CategoryId);
        }

       
    }
}
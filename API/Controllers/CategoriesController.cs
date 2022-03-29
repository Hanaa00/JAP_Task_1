using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly DataContext _context;
        public CategoriesController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Category.ToListAsync();
            
        }

       
        [HttpGet("{CategoryId}")]
      
        public async Task<ActionResult<Category>> GetCategory(int CategoryId)
        {
            return await _context.Category.FindAsync(CategoryId);
        }



    }
}
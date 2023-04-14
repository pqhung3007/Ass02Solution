using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass02Solution.Pages.Manage
{
    public class ProductsModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public ProductsModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Product> Product { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();

            return Page();
        }
    }
}

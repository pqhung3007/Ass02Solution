using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ass02Solution.Models;

namespace Ass02Solution
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public IndexModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Product> Product { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public string pizza { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();

                if (!string.IsNullOrEmpty(pizza))
                {
                    Product = await _context.Products.Where(p => p.ProductName.Contains(pizza)).Include(p => p.Category).ToListAsync();
                }
            }
        }
    }
}

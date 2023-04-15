using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass02Solution.Pages.Manage
{
    public class AddProductModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public AddProductModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
            ViewData["Suppliers"] = new SelectList(_context.Suppliers.ToList(), "SupplierId", "CompanyName");
            ViewData["Categories"] = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
        }
        public IActionResult OnPost()
        {
           
            var errors = ModelState
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();
            Console.WriteLine(errors);
            _context.Products.Add(Product);
            _context.SaveChanges();
            return RedirectToPage("/Manage/Products");
        }
    }
}

using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass02Solution.Pages.Manage
{
    [BindProperties]
    public class EditProductModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public EditProductModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int? id)
        {
            Product = _context.Products.Find(id);
            ViewData["Suppliers"] = new SelectList(_context.Suppliers.ToList(), "SupplierId", "CompanyName");
            ViewData["Categories"] = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Products.Update(Product);
            _context.SaveChanges();
            return RedirectToPage("/Manage/Products");

        }
    }
}

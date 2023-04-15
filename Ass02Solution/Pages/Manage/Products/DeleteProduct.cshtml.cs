using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage
{
    public class DeleteProductModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public DeleteProductModel(PRN221_As02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToPage("/Manage/Products");
        }

      
    }
}

using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage.Categories
{
    public class EditModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public EditModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }
         
        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

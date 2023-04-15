using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage.Categories
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public IndexModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _context.Categories
       .ToList();

        }
    }
}

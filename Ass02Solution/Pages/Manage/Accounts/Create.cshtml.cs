using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public CreateModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Account Account { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(Account);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

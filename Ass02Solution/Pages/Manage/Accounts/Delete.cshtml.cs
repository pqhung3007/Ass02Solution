using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage.Accounts
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public DeleteModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Account Account { get; set; }

        public IActionResult OnGet(int id)
        {
            Account = _context.Accounts.Find(id);
            if (Account != null)
            {
                _context.Accounts.Remove(Account);
                _context.SaveChanges();
            }
                return RedirectToPage("/Accounts/Index");
        }

      
    }
}

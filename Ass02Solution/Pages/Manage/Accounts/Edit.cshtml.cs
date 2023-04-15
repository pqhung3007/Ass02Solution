using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ass02Solution.Pages.Manage.Accounts
{
    public class EditModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public EditModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Account Account { get; set; }
        
        public void OnGet(int id)
        {
            Account = _context.Accounts.Find(id);
            // get all types from accounts and put them into a SelectList
            ViewData["Type"] = new SelectList(_context.Accounts.ToList(), "Type", "AccountId");

        }

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

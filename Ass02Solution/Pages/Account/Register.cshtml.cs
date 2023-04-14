using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ass02Solution.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public RegisterModel(PRN221_As02Context _context)
        {
            this._context = _context;
        }
        
        [BindProperty]
        public Models.Account account { get; set; }

        public async Task<IActionResult> OnPostAsync(Models.Account? account, string? confirmedPassword)
        {
            if (confirmedPassword != account.Password)
            {
                ViewData["Not matched"] = "Please re-confirm the password";
                return Page();
            }
            if (ModelState.IsValid)
            {
                var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.UserName == account.UserName);
                if (acc != null)
                {
                    ViewData["duplicate username"] = "Username already exists";
                    return Page();
                }
                else
                {
                    account.Type = 0; // add member
                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Login");
                }
               
            }
            return Page();
        }
    }
}

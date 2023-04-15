using Ass02Solution.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly PRN221_As02Context _context;

        public LoginModel(PRN221_As02Context context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Models.Account Account { get; set; }
        
        public async Task<IActionResult> OnPost(Models.Account? account)
        {
            Models.Account a = _context.Accounts.FirstOrDefault(a => a.UserName == account.UserName && a.Password == account.Password);
            
            if (a != null)
            {
                HttpContext.Session.SetString("username", a.UserName);
                if (a.Type == 1)
                {
                    return RedirectToPage("/Manage/Products/Index");
                }
                return RedirectToPage("../Products/Index");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("/Products/Index");

        }
    }
}

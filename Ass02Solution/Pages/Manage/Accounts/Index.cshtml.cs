using Ass02Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ass02Solution.Pages.Manage.Accounts
{
    public class IndexModel : PageModel
    {

        private readonly PRN221_As02Context _context;

        public IndexModel(PRN221_As02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Models.Account> Accounts { get; set; }

        public void OnGet()
        {
            Accounts = _context.Accounts.ToList();
        }

    }
}

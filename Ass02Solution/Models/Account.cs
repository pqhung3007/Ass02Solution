using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ass02Solution.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = null!;
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; } = null!;
        public int Type { get; set; }
    }
}

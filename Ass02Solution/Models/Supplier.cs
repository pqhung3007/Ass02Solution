﻿using System;
using System.Collections.Generic;

namespace Ass02Solution.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

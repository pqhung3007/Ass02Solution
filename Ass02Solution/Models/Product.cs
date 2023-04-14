using System;
using System.Collections.Generic;

namespace Ass02Solution.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public double? UnitPrice { get; set; }
        public string ProductImage { get; set; } = null!;

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}

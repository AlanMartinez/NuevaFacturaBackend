using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public virtual ICollection<InvoiceItem> Items { get; set; }
    }
}

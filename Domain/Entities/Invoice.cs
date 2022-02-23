using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Invoice : BaseEntity
    {
        public long InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceItem> Items { get; set; }
        public decimal Total { get; set; }

        public Invoice()
        {
            Date = DateTime.UtcNow;
        }

        public void CalculateTotal()
        {
            var total = 0.0m;
            Items.ToList().ForEach(i => total += i.Product.Price);

            Total = total;
        }
    }
}

using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

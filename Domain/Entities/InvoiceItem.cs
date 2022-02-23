using Domain.Entities;

namespace Domain.Models
{
    public class InvoiceItem : BaseEntity
    {
        public Product Product { get;set;}
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}

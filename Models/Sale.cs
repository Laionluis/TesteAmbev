using System.ComponentModel.DataAnnotations;

namespace TesteAmbev.Models
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItem> Items { get; set; } = new();
    }
}

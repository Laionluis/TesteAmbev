using System.ComponentModel.DataAnnotations;

namespace TesteAmbev.Models
{
    public class SaleItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

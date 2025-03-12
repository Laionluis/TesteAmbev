namespace TesteAmbev.DTOs
{
    public class SaleDTO
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemDTO> Items { get; set; } = new();
    }
}

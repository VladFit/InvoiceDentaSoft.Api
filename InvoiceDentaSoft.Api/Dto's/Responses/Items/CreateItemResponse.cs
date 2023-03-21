namespace InvoiceDentaSoft.Api.Dto_s.Responses.Items
{
    public class CreateItemResponse
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string? Description { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public int? TaxId { get; set; }
        public bool Enabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

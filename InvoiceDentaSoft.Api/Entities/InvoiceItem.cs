namespace InvoiceDentaSoft.Api.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        public double DiscountRate { get; set; }
        public string? DiscountType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public InvoiceItem()
        {

        }
        public InvoiceItem(
            int companyId,
            int invoiceId,
            int? itemId,
            string? name,
            string? sku,
            double quantity,
            double price,
            double total,
            double tax,
            double discountRate,
            string discountType,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null
            )
        {
            CompanyId = companyId;
            InvoiceId = invoiceId;
            ItemId = itemId;
            Name = name;
            Sku = sku;
            Quantity = quantity;
            Price = price;
            Total = total;
            Tax = tax;
            DiscountRate = discountRate;
            DiscountType = discountType;
            CreatedAt = createdAt;
        }
    }
}

namespace InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItem
{
    public class UpdateInvoiceItemRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public int? ItemId { get; set; }
        //public string? Name { get; set; }
        //public string? Sku { get; set; }
        //public double Quantity { get; set; }
        //public double Price { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        public double DiscountRate { get; set; }
        public string? DiscountType { get; set; }
    }
}

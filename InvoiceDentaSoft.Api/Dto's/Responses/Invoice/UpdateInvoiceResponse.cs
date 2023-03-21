namespace InvoiceDentaSoft.Api.Dto_s.Responses.Invoice
{
    public class UpdateInvoiceResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? OrderNumber { get; set; }
        public string? Status { get; set; }
        public DateTime InvoicedAt { get; set; }
        public DateTime DueAt { get; set; }
        public double Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public double CurrencyRate { get; set; }
        public int CategoryId { get; set; }
        public int ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactTaxNumber { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? Notes { get; set; }
        public string? Footer { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

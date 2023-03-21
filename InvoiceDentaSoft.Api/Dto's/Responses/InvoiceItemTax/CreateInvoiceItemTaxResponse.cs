namespace InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceItemTax
{
    public class CreateInvoiceItemTaxResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public int TaxId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

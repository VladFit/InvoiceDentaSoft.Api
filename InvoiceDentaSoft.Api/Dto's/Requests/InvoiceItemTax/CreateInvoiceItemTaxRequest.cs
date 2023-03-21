namespace InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceItemTax
{
    public class CreateInvoiceItemTaxRequest
    {
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public int TaxId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}

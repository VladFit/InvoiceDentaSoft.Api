namespace InvoiceDentaSoft.Api.Entities
{
    public class InvoiceItemTax
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

        public InvoiceItemTax()
        {

        }

        public InvoiceItemTax(
            int companyId,
            int invoiceId,
            int invoiceItemId,
            int taxId,
            string name,
            double amount,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null
        )
        {
            CompanyId = companyId;
            InvoiceId = invoiceId;
            InvoiceItemId = invoiceItemId;
            TaxId = taxId;
            Name = name;
            Amount = amount;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

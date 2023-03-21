namespace InvoiceDentaSoft.Api.Entities
{
    public class InvoiceTotal
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public int SortOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public InvoiceTotal()
        {

        }
        public InvoiceTotal(
            int companyId,
            int invoiceId,
            string? code,
            string? name,
            double amount,
            int sortOrder,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null)
        {
            CompanyId = companyId;
            InvoiceId = invoiceId;
            Code = code;
            Name = name;
            Amount = amount;
            SortOrder = sortOrder;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

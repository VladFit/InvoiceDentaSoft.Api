namespace InvoiceDentaSoft.Api.Entities
{
    public class InvoiceHistory
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public string Status { get; set; }
        public bool Notify { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public InvoiceHistory()
        {

        }

        public InvoiceHistory(
            int companyId,
            int invoiceId,
            string status,
            bool notify,
            string? description,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null
            )
        {
            CompanyId = companyId;
            InvoiceId = invoiceId;
            Status = status;
            Notify = notify;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }

}
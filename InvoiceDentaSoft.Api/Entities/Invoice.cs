namespace InvoiceDentaSoft.Api.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string InvoiceNumber { get; set; }
        public string? OrderNumber { get; set; }
        public string Status { get; set; }
        public DateTime InvoicedAt { get; set; }
        public DateTime DueAt { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public double CurrencyRate { get; set; }
        public int CategoryId { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
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

        public Invoice()
        {

        }

        public Invoice(
            int companyId,
            string invoiceNumber,
            string? orderNumber,
            string status,
            DateTime invoicedAt,
            DateTime dueAt,
            double amount,
            string currencyCode,
            double currencyRate,
            int categoryId,
            int contactId,
            string contactName,
            string? contactEmail,
            string? contactTaxNumber,
            string? contactPhone,
            string? contactAddress,
            string? notes,
            string? footer,
            int? parentId,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null
        )
        {
            CompanyId = companyId;
            InvoiceNumber = invoiceNumber;
            OrderNumber = orderNumber;
            Status = status;
            InvoicedAt = invoicedAt;
            DueAt = dueAt;
            Amount = amount;
            CurrencyCode = currencyCode;
            CurrencyRate = currencyRate;
            CategoryId = categoryId;
            ContactId = contactId;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactTaxNumber = contactTaxNumber;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            Notes = notes;
            Footer = footer;
            ParentId = parentId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}


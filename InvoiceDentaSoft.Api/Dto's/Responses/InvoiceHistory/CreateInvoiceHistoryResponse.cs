namespace InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceHistory
{
    public class CreateInvoiceHistoryResponse
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
    }
}

namespace InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceHistory
{
    public class UpdateInvoiceHistoryRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public string Status { get; set; }
        public bool Notify { get; set; }
        public string? Description { get; set; }
    }
}

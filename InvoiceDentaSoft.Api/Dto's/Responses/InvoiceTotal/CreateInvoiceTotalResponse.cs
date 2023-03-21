namespace InvoiceDentaSoft.Api.Dto_s.Responses.InvoiceTotal
{
    public class CreateInvoiceTotalResponse
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
    }
}

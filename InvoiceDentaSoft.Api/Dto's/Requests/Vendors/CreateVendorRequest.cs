namespace InvoiceDentaSoft.Api.Dto_s.Requests.Vendors
{
    public class CreateVendorRequest
    {
        public int CompanyId { get; set; }
        public int? Type { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
        public string? TaxNumber { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? CurrencyCode { get; set; }
        public bool Enabled { get; set; }
        public string? Reference { get; set; }
        public int ClinicId { get; set; }
    }
}

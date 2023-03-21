namespace InvoiceDentaSoft.Api.Dto_s.Responses.Taxes
{
    public class CreateTaxResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

namespace InvoiceDentaSoft.Api.Dto_s.Requests.Category
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public bool Enabled { get; set; }
    }
}

namespace InvoiceDentaSoft.Api.Dto_s.Responses.Category
{
    public class UpdateCategoryResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public bool Enabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

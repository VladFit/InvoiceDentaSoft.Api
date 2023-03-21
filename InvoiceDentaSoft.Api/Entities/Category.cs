namespace InvoiceDentaSoft.Api.Entities
{
    public class Category
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

        public Category()
        {
            
        }

        public Category(
            int companyId,
            string? name,
            string? type,
            string? color,
            bool enabled,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null)
        {
            CompanyId = companyId;
            Name = name;
            Type = type;
            Color = color;
            Enabled = enabled;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

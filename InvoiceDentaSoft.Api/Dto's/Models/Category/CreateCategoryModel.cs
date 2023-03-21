namespace InvoiceDentaSoft.Api.Dto_s.Models.Category
{
    public class CreateCategoryModel
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public bool Enabled { get; set; }

        public CreateCategoryModel()
        {
            
        }

        public CreateCategoryModel(
            int companyId,
            string name,
            string type,
            string color,
            bool enabled)
        {
            CompanyId = companyId;
            Name = name;
            Type = type;
            Color = color;
            Enabled = enabled;
        }
    }
}

namespace InvoiceDentaSoft.Api.Entities
{
    public class Tax
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

        public Tax()
        {

        }
        public Tax(
            int companyId,
            string name,
            double rate,
            string type,
            bool enabled,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null
            )
        {
            CompanyId = companyId;
            Name = name;
            Rate = rate;
            Type = type;
            Enabled = enabled;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

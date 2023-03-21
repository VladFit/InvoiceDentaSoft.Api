namespace InvoiceDentaSoft.Api.Entities.LoockUps
{
    public class VendorType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public VendorType()
        {
            
        }

        public VendorType(string name)
        {
            Name = name;
        }
    }


}

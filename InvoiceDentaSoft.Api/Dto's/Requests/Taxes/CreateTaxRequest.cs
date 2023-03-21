﻿namespace InvoiceDentaSoft.Api.Dto_s.Requests.Taxes
{
    public class CreateTaxRequest
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public string Type { get; set; }
        public bool Enabled { get; set; }
    }
}

﻿namespace InvoiceDentaSoft.Api.Dto_s.Requests.InvoiceTotal
{
    public class CreateInvoiceTotalRequest
    {
        public int CompanyId { get; set; }
        public int InvoiceId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public double Amount { get; set; }
        public int SortOrder { get; set; }
    }
}

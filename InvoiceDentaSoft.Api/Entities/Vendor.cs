﻿namespace InvoiceDentaSoft.Api.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Type { get; set; }
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
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Vendor()
        {
            
        }
        public Vendor(
            int companyId, 
            string? type, 
            string? name, 
            string? email,
            int userId,
            string? taxNumber,
            string phone,
            string? address,
            string? website,
            string? currencyCode,
            bool enabled,
            string? reference,
            int clinicId,
            DateTime? createdAt,
            DateTime? updatedAt = null,
            DateTime? deletedAt = null)
        {
            CompanyId = companyId;
            Type = type;
            Name = name;
            Email = email;
            UserId = userId;
            TaxNumber = taxNumber;
            Phone = phone;
            Address = address;
            Website = website;
            CurrencyCode = currencyCode;
            Enabled = enabled;
            Reference = reference;
            ClinicId = clinicId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }
    }
}

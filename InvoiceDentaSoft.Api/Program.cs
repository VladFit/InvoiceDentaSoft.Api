using InvoiceDentaSoft.Api.Context;
using InvoiceDentaSoft.Api.Entities.LoockUps;
using InvoiceDentaSoft.Api.Service.Repositories;
using InvoiceDentaSoft.Api.Service.Repositories.Generic;
using InvoiceDentaSoft.Api.Service.Repositories.Intefaces;
using InvoiceDentaSoft.Api.Service.Repositories.Interfaces;
using InvoiceDentaSoft.Api.Service.Services;
using InvoiceDentaSoft.Api.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IInvoiceHistoryService, InvoiceHistoryService>();
builder.Services.AddScoped<IInvoiceHistoryRepository, InvoiceHistoryRepository>();

builder.Services.AddScoped<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

builder.Services.AddScoped<IInvoiceItemTaxService, InvoiceItemTaxService>();
builder.Services.AddScoped<IInvoiceItemTaxRepository, InvoiceItemTaxRepository>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<IInvoiceTotalService, InvoiceTotalService>();
builder.Services.AddScoped<IInvoiceTotalRepository, InvoiceTotalRepository>();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<ITaxRepository, TaxRepository>();

builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();

builder.Services.AddScoped<IGenericRepository<VendorType>, GenericRepository<VendorType>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

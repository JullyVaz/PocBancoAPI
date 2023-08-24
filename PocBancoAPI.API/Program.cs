using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Business;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Data.Repositories;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.Services;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.Shared.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountBusiness, AccountBusiness>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IFinancialOperationService, FinancialOperationService>();
builder.Services.AddScoped<IFinancialOperationBusiness, FinancialOperationBusiness>();
builder.Services.AddScoped<IFinancialOperationRepository, FinancialOperationRespository>();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



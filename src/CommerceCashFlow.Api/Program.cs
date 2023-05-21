using CommerceCashFlow.Application;
using CommerceCashFlow.Application.CommandHandlers;
using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Models;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Core.Repositories;
using CommerceCashFlow.Core.Repositories.Caching;
using CommerceCashFlow.Core.Repositories.Interfaces;
using CommerceCashFlow.Core.Services;
using CommerceCashFlow.Core.Services.Interfaces;
using CommerceCashFlow.Infrastructure;
using CommerceCashFlow.Infrastructure.Data;
using CommerceCashFlow.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
string RedisConnectionString = builder.Configuration.GetSection("RedisCache")["ConnectionString"];
// Register services
builder.Services.AddDbContext<CommerceCashFlowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
//Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CommerceCashFlow API", Version = "v1" });
});

var services = builder.Services;
services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining(typeof(Program));
});
services.AddDistributedRedisCache(options =>
{
    options.Configuration = RedisConnectionString;
});
services.AddAutoMapper(typeof(Program), typeof(MappingProfile));
services.AddSingleton<IDistributedCache, RedisCache>();

// Register repositories and services
services.AddScoped<IMerchantRepository, MerchantRepository>();
 services.AddScoped<IMerchantService, MerchantService>();

services.AddScoped<ITransactionRepository, TransactionRepository>();
services.AddScoped<ITransactionService, TransactionService>();


services.AddScoped<IReportRepository, ReportRepository>();
services.AddScoped<IReportService, ReportService>();
services.AddScoped<IReportCache, ReportCache>();
//Add service CreateMerchantCommand registration
services.AddScoped<IRequestHandler<CreateMerchantCommand, Guid>, CreateMerchantCommandHandler>();
services.AddScoped<IRequestHandler<GetMerchantQuery, MerchantViewModel>, GetMerchantQueryHandler>();
services.AddScoped<IRequestHandler<GetTransactionsQuery, List<TransactionsViewModel>>, GetTransactionsQueryHandler>();
services.AddScoped<IRequestHandler<CreateTransactionCommand, int>, CreateTransactionCommandHandler>();
services.AddScoped<IRequestHandler<GetReportQuery, ReportViewModel>, GetReportQueryHandler>();

//TODO: Create a new class for all the DI
//Add Swagger
var app = builder.Build();

app.UseSwagger();
//Add Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommerceCashFlow API V1");
});


// Configure the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
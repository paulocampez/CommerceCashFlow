using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<CommerceCashFlowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Register MediatR and handlers
builder.Services.AddMediatR(typeof(CreateMerchantCommand).Assembly);
builder.Services.AddMediatR(typeof(GetMerchantQuery).Assembly);

// Register repositories and services
 builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
 builder.Services.AddScoped<IMerchantService, MerchantService>();

var app = builder.Build();

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

app.Run();
using CommerceCashFlow.Application.CommandHandlers;
using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Application.Queries;
using CommerceCashFlow.Core.Repositories;
using CommerceCashFlow.Core.Services;
using CommerceCashFlow.Infrastructure;
using CommerceCashFlow.Infrastructure.Data;
using CommerceCashFlow.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

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


// Register repositories and services
 services.AddScoped<IMerchantRepository, MerchantRepository>();
 services.AddScoped<IMerchantService, MerchantService>();
//Add service CreateMerchantCommand registration
services.AddScoped<IRequestHandler<CreateMerchantCommand, string>, CreateMerchantCommandHandler>();
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
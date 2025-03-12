using System.Reflection;
using TesteAmbev.Data;
using TesteAmbev.Mappings;
using TesteAmbev.Repositories.Interfaces;
using TesteAmbev.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

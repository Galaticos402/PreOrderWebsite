using API.Middleware;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Services;
using BusinessLayer.Services.AccountService;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var services = builder.Services;
var Configuration = builder.Configuration;
services.AddDbContext<DatabaseContext>(options =>
        options
        .UseSqlServer(Configuration.GetConnectionString("Conn"))) ;

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
});
//Tao mapper
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

services.AddScoped<AddressRepository>();
services.AddScoped<IUnitOfWork,UnitOfWork>();

services.AddScoped<IAccountService>(services => new AccountService(services.GetRequiredService<IUnitOfWork>(), services.GetRequiredService<IMapper>()));
//services.AddScoped<IProductService>(services => new ProductService(services.GetRequiredService<IUnitOfWork>(), services.GetService<IMapper>()));
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IProductCampaignService, ProductCampaignService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

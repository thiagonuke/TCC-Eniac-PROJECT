using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjetoModeloApi.IoC;
using System.Net.Mail;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Services;
using UrbanFarming.Service.AppService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UrbanContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});

builder.Services.StartRegisterServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS",
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .WithHeaders("*")
                                .WithHeaders("*")
                                .WithMethods("*");
                      });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Zentrix", 
        Version = "v1",
        Description = "API do sistema ERP Zentrix",
    });
});
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<EmailService>();
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

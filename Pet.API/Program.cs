
using Microsoft.EntityFrameworkCore;
using Pet.Domain.Interfaces;
using Pet.Repository.Banco;
using Pet.Repository.Repository;
using Pet.Service.Interfaces;
using Pet.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Pet.Service.AutoMappers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var services = builder.Services;
var config = builder.Configuration;

// Add AutoMapper with a custom mapping profile
services.AddAutoMapper(typeof(Mapper));

// Add services to the container.

//builder.Services.AddDbContext<MeuBanco>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Padrao")));
services.AddDbContext<MeuBancoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Padrao"));
});

services.AddScoped<IPetService, PetService>();
services.AddScoped<IPetRepository, PetRepository>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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

using BussinesLayer.Services.ServicesRegister;
using DataLayer.Interfaces.IUnit;
using FluentValidation;
using FluentValidation.AspNetCore;
using InveroryMangmentsAPI.Middlewhere;
using InveroryMangmentsAPI.Validators.ValidationEntities.CategoryValidation;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// connection DB
    builder.Services.AddDbContext<DataLayer.Data.AppDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        ));

// add unit of work
builder.Services.AddScoped<IUnitOfWork, DataLayer.UnitOfWork.UnitofWork>();


// add Validation 
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<categoryV>();

// add automapper
// scan every classs 
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// scan one and take all from path assembly.
builder.Services.AddAutoMapper(typeof(BussinesLayer.Mappers.CategoryProfile).Assembly);

// add services 
builder.Services.AddServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Middlewhere to handle exceptions globally
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionsMiddlewhere>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using ZolsExpenseTracker.Api.Infrastructure.Repositories;
using ZolsExpenseTracker.Api.Infrastructure.Data;
using ZolsExpenseTracker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExpenseDbContext>(opt => 
    opt.UseInMemoryDatabase("ExpenseStore"));

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

builder.Services.AddControllers();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



using EmployeeAPI.Data.ContextData;
using EmployeeAPI.Services.Services.Interfaces;
using EmployeeAPI.Services.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDB")));
builder.Services.AddScoped<ICascadingLogic, CascadingLogic>();
builder.Services.AddScoped<ICRUDLogic, CRUDLogic>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


using BackEndProyectoWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FacturacionProyectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiConexion")));

builder.Services.AddDbContext<FacturacionPassword>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiConexion")));

builder.Services.AddTransient<FacturacionPassword>();
var app = builder.Build();
//desabilitar los cors 
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

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

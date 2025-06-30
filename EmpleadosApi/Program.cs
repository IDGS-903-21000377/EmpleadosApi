using EmpleadosApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen();



var connectionString =
    builder.Configuration.GetConnectionString("StringCadena");
builder.Services.AddDbContext<BdEmpleados903Context>(options =>
 options.UseSqlServer(connectionString));



builder.Services.AddCors(options =>

{
    options.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("nuevaPolitica");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

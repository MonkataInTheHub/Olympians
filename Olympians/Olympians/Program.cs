using Olympians.Models.Databases;
using Olympians.Models.Interfaces;
using Olympians.Services;
using Olympians.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IOlympicsDatabase, OlympianDatabase>();
builder.Services.AddSingleton<IBoxerService, BoxerService>();
builder.Services.AddSingleton<ISprinterService, SprinterService>();
builder.Services.AddSingleton<IOlympianService, OlympianService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

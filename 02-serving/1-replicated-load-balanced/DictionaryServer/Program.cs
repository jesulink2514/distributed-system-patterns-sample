using DictionaryServer;
using DictionaryServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DictionaryProvider>();
builder.Services.AddHealthChecks()
    .AddCheck<DictionaryHealthCheck>("Dictionary Data");

var app = builder.Build();

var dicProv = app.Services.GetService<DictionaryProvider>();
if (dicProv == null) throw new InvalidOperationException("Missing provider for DictionaryProvider");
dicProv.LoadAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/health");

app.MapControllers();

app.Run();


using SurveyApp.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using SurveyApp.API.Extensions;
using SurveyApp.Infrastructure.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionStringSurvey = builder.Configuration.GetConnectionString("db");

builder.Services.AddInjections(connectionStringSurvey);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<SurveyDbContext>();
context.Database.EnsureCreated();
DbSeeding.SeedDatabase(context);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

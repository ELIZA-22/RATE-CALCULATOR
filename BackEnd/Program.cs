
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackEnd;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        _ = builder.Services.AddAuthorization();

           builder.Services.AddControllers();
          
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }
        app.UseCors((a) => a.AllowAnyOrigin());
        
        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();

           app.MapControllers();
        // var summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // _ = app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        // {
        //     var forecast = Enumerable.Range(1, 5).Select(index =>
        //         new WeatherForecast
        //         {
        //             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //             TemperatureC = Random.Shared.Next(-20, 55),
        //             Summary = summaries[Random.Shared.Next(summaries.Length)]
        //         })
        //         .ToArray();
        //     return forecast;
        // })
        // .WithName("GetWeatherForecast");

        app.Run();
    }

    // private class WeatherForecast
    // {
    //     public DateOnly Date { get; set; }
    //     public int TemperatureC { get; set; }
    //     public string Summary { get; set; }
    // }
}

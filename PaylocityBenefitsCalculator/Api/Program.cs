using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Add controllers
        builder.Services.AddControllers();

        // Register repositories
        builder.Services.RegisterRepositories();

        // Register services
        builder.Services.RegisterServices();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Employee Benefit Cost Calculation Api",
                Description = "Api to support employee benefit cost calculations"
            });
        });

        var allowLocalhost = "allow localhost";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(allowLocalhost,
                policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(allowLocalhost);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

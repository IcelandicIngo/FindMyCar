using API.Middlewares;
using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class HostingExtensions
{
    /// <summary>
    /// Configures services used by 'WebApplication' when built.
    /// </summary>
    /// <param name="builder">WebApplication builder.</param>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<VehicleContext>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("FindMyCar"));
        });
        return builder;
    }

    /// <summary>
    /// Configures a 'WebApplication' instance.
    /// </summary>
    /// <param name="app">WebApplication instance</param>
    public static WebApplication Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        return app;
    }
}

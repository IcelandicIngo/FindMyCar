using API.Middlewares;
using FindMyCar.Core.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;
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
        builder.Host.UseSerilog((ctx,cfg)=>
        {
            //Override Few of the Configurations
            cfg.Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                .WriteTo.Console(new RenderedCompactJsonFormatter())
                .WriteTo.GrafanaLoki(ctx.Configuration["Loki"]);
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
        app.ConfigureMetrics();
        app.UseMiddleware<ExceptionMiddleware>();
        app.MapControllers();
        return app;
    }

    /// <summary>
    /// Configure metrics for WebApplication
    /// </summary>
    /// <param name="app">WebApplication to configure metrics for.</param>
    public static WebApplication ConfigureMetrics(this WebApplication app)
    {
        var counter = Metrics.CreateCounter("api_path_counter", "Counts requests to the API endpoints", new CounterConfiguration
        {
            LabelNames = new[] { "method", "endpoint" }
        });
        app.Use((context, next) =>
        {
            counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
            return next();
        });
        app.UseMetricServer();
        app.UseHttpMetrics();    
        return app;
    }    
}

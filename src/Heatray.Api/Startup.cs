using FluentValidation.AspNetCore;
using Heatray.Api.gRPC.Interceptors;
using Heatray.Api.gRPC.Services;
using Heatray.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;

namespace Heatray.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("HeatrayPolicy", builder =>
        {
            builder.SetIsOriginAllowed(_ => true);
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
            builder.AllowCredentials();
        }));

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });
        services.AddOptions();
        services.AddInfrastructure(Configuration);
        services.AddGrpc(options =>
        {
            options.Interceptors.Add<CorrelationInterceptor>();
            options.Interceptors.Add<ErrorInterceptor>();
            options.Interceptors.Add<AuthInterceptor>();
        }).AddJsonTranscoding();
        services.AddGrpcSwagger();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1.0",
                new OpenApiInfo { Title = "heatray GRPC", Version = "v1.0" });
            var filePath = Path.Combine(AppContext.BaseDirectory, "Heatray.Api.xml");
            options.IncludeXmlComments(filePath);
            options.IncludeGrpcXmlComments(filePath, true);
            options.AddSecurityDefinition("secret-key", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "secret-key",
                Description = "Enter your GRPC secret key."
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "secret-key"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("HeatrayPolicy");
        app.UseForwardedHeaders();
        app.UseStaticFiles();
        app.UseRouting();
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "";
            options.DocumentTitle = "heatray-api | heatray";
            options.InjectStylesheet("/assets/css/heatray-swagger.css");
            options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "heatray GRPC v1.0");
        });
        app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
        app.UseEndpoints(endpoints => { endpoints.MapGrpcService<MessageProcessorService>(); });
    }
}
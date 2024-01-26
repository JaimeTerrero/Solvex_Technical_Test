using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly)
                .ToList();

                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Solvex_Technical_App_API",
                    Description = "Esta API se encarga de manejar los datos de la aplicacion de Solvex_Technical_App.",
                    Contact = new OpenApiContact
                    {
                        Name = "Jaime Terrero",
                        Email = "jaimeterrero28@gmail.com",
                        Url = new Uri("https://github.com/JaimeTerrero")
                    }
                });

                options.EnableAnnotations();
                options.DescribeAllParametersInCamelCase();
                
                
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}

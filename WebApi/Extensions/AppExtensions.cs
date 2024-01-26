﻿using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi_API");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }
    }
}

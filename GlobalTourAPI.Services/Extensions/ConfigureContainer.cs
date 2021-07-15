using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalTourAPI.Services.Extensions
{
    public static class ConfigureContainer
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Global tour API");
                setupAction.RoutePrefix = "GlobalTourAPI";
            });
        }
    }
}

﻿using DNTFrameworkCore.Exceptions;
using DNTFrameworkCore.FluentValidation;
using DNTFrameworkCore.TestAPI.Application;
using DNTFrameworkCore.TestAPI.Hubs;
using DNTFrameworkCore.TestAPI.Infrastructure;
using DNTFrameworkCore.TestAPI.Resources;
using DNTFrameworkCore.Web;
using DNTFrameworkCore.Web.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DNTFrameworkCore.TestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFramework()
                .WithModelValidation()
                .WithFluentValidation()
                .WithMemoryCache()
                .WithSecurityService()
                .WithBackgroundTaskQueue()
                .WithRandomNumber();

            services.AddWebFramework()
                .WithPermissionAuthorization()
                .WithProtection()
                .WithPasswordHashAlgorithm()
                .WithQueuedHostedService()
                .WithAntiXsrf()
                .WithEnvironmentPath();

            services.AddInfrastructure(Configuration);
            services.AddApplication(Configuration);
            services.AddResources();
            services.AddWebApp();
            services.AddJwtAuthentication(Configuration);

            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "dbo";
                options.TableName = "Cache";
            });

            services.Configure<ExceptionOptions>(Configuration.GetSection("Exception"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIf(env.IsProduction(), _ => _.UseHsts());

            app.UseExceptionHandling((exception, result) =>
            {
                if (exception is SecurityTokenExpiredException)
                {
                    result.FriendlyMessage = "authentication token expired";
                    result.StatusCode = StatusCodes.Status401Unauthorized;
                    result.ExceptionHandled = true;
                }
            });

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hubs/notification");
            });
        }
    }
}
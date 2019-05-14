using System;
using System.Net.Http;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neudesic.YoEvents.EventManagement.Adapters;
using Neudesic.YoEvents.EventManagement.Application.AutoMapper;
using Neudesic.YoEvents.EventManagement.Application.Interfaces;
using Neudesic.YoEvents.EventManagement.Application.Services;
using Neudesic.YoEvents.EventManagement.Application.Validators;
using Neudesic.YoEvents.EventManagement.Infrastructure;
using Polly;
using Polly.Extensions.Http;
using Swashbuckle.AspNetCore.Swagger;

namespace Neudesic.YoEvents.EventManagement.API
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            services.AddDbContext<EventManagementDbContext>(options =>
                     options.UseNpgsql(Configuration.GetConnectionString("EventManagementPostgressConnectionString")));

            services.AddScoped<IEventManagementDbContext, EventManagementDbContext>();
            services.AddScoped<IEventService, EventService>();

            services.AddHttpClient<IOrganizationAdapter, OrganizationAdapter>()
                        .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
                        .AddPolicyHandler(GetRetryPolicy());

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EventValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Neudesic.YoEvents.EventManagement.API", Version = "v1" });
                //c.AddFluentValidationRules();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Neudesic.YoEvents.EventManagement.API");
                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}

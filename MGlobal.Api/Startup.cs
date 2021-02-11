using MGlobal.Core.Data.Services;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Factory;
using MGlobal.Core.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace MGlobal.Api
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
            // DI            
            services.AddScoped<IEmployeeClientService, EmployeeClientService>();
            services.AddScoped<IEmployeeDtoManager, EmployeeDtoManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ISalaryFactory, SalaryFactory>();

            // Add HttpClient Factory
            services.AddHttpClient<IHttpService, HttpService>()
            .AddPolicyHandler(GetRetryPolicy());

            // Enable Cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:4200"));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("http://localhost:4200"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2000));
        }
    }
}

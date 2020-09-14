using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using FindCombsApi.Models;
using FindCombsApi.Application.Interfaces;
using FindCombsApi.Application.Services;
using FindCombsApi.Infrastructure.Repositories;
using FindCombsApi.Infrastructure.Interfaces;

namespace FindCombsApi
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
            services.Configure<CombinationsDatabaseSettings>(
                Configuration.GetSection(nameof(CombinationsDatabaseSettings)));

            services.AddSingleton<ICombinationsDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CombinationsDatabaseSettings>>().Value);
            
            services.AddTransient<ICombinationService, CombinationService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IRequestRepository, RequestRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

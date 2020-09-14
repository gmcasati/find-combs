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
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace FindCombsApi
{
    public class Startup
    {
        private static string GetPathOfXmlFromAssembly() => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Find Combs API with Documentation", Version = "v1" });
                options.IncludeXmlComments(GetPathOfXmlFromAssembly());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Find Combs API width Documentation V1");
                // c.RoutePrefix = string.Empty;
            });

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

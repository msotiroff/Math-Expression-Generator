using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Models.Factories.Implementations;
using MathExpressionGenerator.Models.Factories.Interfaces;
using MathExpressionGenerator.Services.Implementations;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace MathExpressionGenerator.Web
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
            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .Configure<FileContentTypes>(this.Configuration.GetSection("FileContentTypes"));

            services.AddSingleton<ILanguageContainer, LanguageContainer>();
            services.AddSingleton<IExpressionContainer, ExpressionContainer>();

            services.AddTransient<IMathExpressionService, MathExpressionService>();
            services.AddTransient<IExpressionExtractor, ExpressionExtractor>();
            services.AddTransient<IMathExpressionFactory, MathExpressionFactory>();
            services.AddTransient<IFileService, FileService>();
            
            services.AddTransient<Random>(sp => new Random());
            services.AddTransient<StringBuilder>(sp => new StringBuilder());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler(appBuilder => appBuilder
                    .Run(async context => 
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Bad request.");
                    }));

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    "deafult",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

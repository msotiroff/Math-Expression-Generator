using Amazon.DynamoDBv2;
using DotNetExtensions.AspNetCore.Common;
using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Models.Factories.Implementations;
using MathExpressionGenerator.Models.Factories.Interfaces;
using MathExpressionGenerator.Services.Implementations;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Abstractions;
using MathExpressionGenerator.Web.Configuration;
using MathExpressionGenerator.Web.Data.Abstractions;
using MathExpressionGenerator.Web.Data.DAL;
using MathExpressionGenerator.Web.Infrastructure.Containers;
using MathExpressionGenerator.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .Configure<FileContentTypes>(this.Configuration.GetSection("FileContentTypes"))
                .Configure<LambdaOptions>(this.Configuration.GetSection("LambdaOptions"));

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<LambdaOptions>>().Value);
            services.AddSingleton<ILanguageContainer, LanguageContainer>();
            services.AddSingleton<IBrowserRepository>(sp =>
                new BrowserRepository(
                    sp.GetRequiredService<IAmazonDynamoDB>(),
                    Environment.GetEnvironmentVariable("BROWSERS_TABLE")));

            services.AddScoped<IUserSessionContainer, UserSessionContainer>();

            services.AddDefaultAWSOptions(this.Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddTransient<IMathExpressionService, MathExpressionService>();
            services.AddTransient<IExpressionExtractor, ExpressionExtractor>();
            services.AddTransient<IMathExpressionFactory, MathExpressionFactory>();
            services.AddTransient<IFileService, FileService>();

            services.AddTransient(sp => new Random());
            services.AddTransient(sp => new StringBuilder());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Environment.SetEnvironmentVariable(
                    "BROWSERS_TABLE",
                    "math_system_browsers_stage");

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app
                .Use(async (context, next) =>
                {
                    await HandleExceptionAsync(context, next);
                })
                .LogRequestorIpAddress((str) => Console.WriteLine(str))
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseAnonymousBrowser(TimeSpan.FromDays(30))
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        "deafult",
                        "{controller}/{action}");
                });
        }

        private static async Task HandleExceptionAsync(
            HttpContext context, Func<Task> next)
        {
            try
            {
                await next.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EXCEPTION THROWN]: {ex.Message}");

                Console.WriteLine(ex.StackTrace);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync("Bad request.");
            }
        }
    }
}

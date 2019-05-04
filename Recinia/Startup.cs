using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Recinia.Entities;
using Recinia.Models;
using Recinia.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Facebook;
using Recinia.Repository;

namespace Recinia
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //private string _moviesApiKey = null;
        public void ConfigureServices(IServiceCollection services)
        {
            //_moviesApiKey = Configuration["Movies:ServiceApiKey"];
            services.AddApplicationInsightsTelemetry();
            services.AddScoped<IMyService, MyService>();
            //entity frame work injection
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connection = @"Server=(localdb)\MSSQLLocalDB; Initial Catalog = ProfileDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));
            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<MessageSenderOptions>(Configuration);
            services.AddTransient<IEmailSend,MessageSend>();
            services.AddTransient<ISmsSend, MessageSend>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            services.AddAuthentication()
            .AddFacebook(options =>
            {
                options.AppId = Configuration["Authentication:Facebook:Id"];
                options.AppSecret = Configuration["Authentication:Facebook:appsecret"];
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,ApplicationDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseApplicationInsightsRequestTelemetry();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Main/Error");
            }
            app.UseApplicationInsightsExceptionTelemetry();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseAuthentication();
            //app.UseFacebookAuthentication(new FacebookOptions()
            //{
            //    AppId = Configuration["Authentication:Facebook:Id"],
            //    AppSecret = Configuration["Authentication:Facebook:AppSecret"]
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
                routes.MapRoute(name: "haja", template: "logout", defaults: new { controller = "Main", action = "LogOff" });
                routes.MapRoute(name: "edition", template: "api", defaults: new { controller = "ProfileApi", action = "EditOrganization" });
            });
            Initializer.InitializeContext(context);
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}

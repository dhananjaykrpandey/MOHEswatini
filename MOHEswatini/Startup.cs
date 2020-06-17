using System;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOHEswatini.Controllers;
using MOHEswatini.Models;
using Rotativa.AspNetCore;
using WebMarkupMin.AspNetCore2;
namespace MOHEswatini
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

            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {

                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = ClsUtility.MimeTypes();
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

            });

            services.AddControllersWithViews();

            //if (Env.IsEnvironment("Development"))
            //{
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //}
            services.AddWebOptimizer();

            services.AddWebMarkupMin(
              options =>
              {
                  options.AllowMinificationInDevelopmentEnvironment = true;
                  options.AllowCompressionInDevelopmentEnvironment = true;
                  options.DisablePoweredByHttpHeaders = true;
              })
              .AddHtmlMinification(
                options =>
                {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                    // More options if you like so
                })
           .AddHttpCompression();

            services.AddDbContext<DbMOHEswatini>(options => options.UseSqlServer(Configuration.GetConnectionString("MOHEswatiniDBConnection")));
            services.AddMvc();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Logins/Index";
                options.AccessDeniedPath = "/Home/Index";
                options.ReturnUrlParameter = "/Home/Index";
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.MaxAge = TimeSpan.FromSeconds(30); 
                options.Cookie.IsEssential = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;

                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                //options.LoginPath = new PathString("/Logins/Index"); ;
                //options.AccessDeniedPath = new PathString("/Logins/Index"); ;
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            app.UseRewriter(new RewriteOptions().Add(new RedirectWwwRule()));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseWebOptimizer();
            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Cache static files for 30 days
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
                    ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
                }
            });

            
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(100000)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            app.UseCookiePolicy();
            app.UseSession();
            app.UseSitemapMiddleware("https://www.arnikainfotech.com");
            app.UseRobotsTxt(env);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            // var webRootPath = env.WebRootPath;
            // call rotativa conf passing env to get web root path
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa"); 
        }

        
    }
}

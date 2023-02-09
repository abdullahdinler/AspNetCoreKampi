using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKampi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspNetCoreKampi
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
            services.AddControllersWithViews();


            // Global bir filtreleme iþlemi yapýldý
            services.AddMvc(confing =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                confing.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                // Bu ayar, kullanýcýnýn giriþ yapmadýðý durumda yönlendirileceði sayfanýn URL'sini belirtir.
                x.LoginPath = "/AuthorLogin/Index";
            });

            services.ConfigureApplicationCookie(options =>
            {
                // çerezin sadece HTTP istekleri tarafýndan okunabileceðini belirtir. Bu, çerezin JavaScript tarafýndan okunmasýný ve dolayýsýyla XSS saldýrýlarýna karþý bir koruma saðlar.
                options.Cookie.HttpOnly = true;

                // cookie nin süresi
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                // Giris yapýldiði zaman yonlendileceði sayfa
                options.LoginPath = "/AuthorLogin/Index";

                // Giriþ yaptýðý sürece cerezin süresi uzatýlýr.
                options.SlidingExpiration = true;

                // Ýzinsiz giriþ iþlemi yapýlmya calýþtýðý zaman yönlendireleciði sayfa
                options.AccessDeniedPath = "/Blog/Index";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            // Error Sayasý Yönlendirme
            //app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

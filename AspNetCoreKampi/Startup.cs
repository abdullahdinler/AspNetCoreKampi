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


            // Global bir filtreleme i�lemi yap�ld�
            services.AddMvc(confing =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                confing.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                // Bu ayar, kullan�c�n�n giri� yapmad��� durumda y�nlendirilece�i sayfan�n URL'sini belirtir.
                x.LoginPath = "/AuthorLogin/Index";
            });

            services.ConfigureApplicationCookie(options =>
            {
                // �erezin sadece HTTP istekleri taraf�ndan okunabilece�ini belirtir. Bu, �erezin JavaScript taraf�ndan okunmas�n� ve dolay�s�yla XSS sald�r�lar�na kar�� bir koruma sa�lar.
                options.Cookie.HttpOnly = true;

                // cookie nin s�resi
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                // Giris yap�ldi�i zaman yonlendilece�i sayfa
                options.LoginPath = "/AuthorLogin/Index";

                // Giri� yapt��� s�rece cerezin s�resi uzat�l�r.
                options.SlidingExpiration = true;

                // �zinsiz giri� i�lemi yap�lmya cal��t��� zaman y�nlendireleci�i sayfa
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

            // Error Sayas� Y�nlendirme
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

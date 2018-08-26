using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc0826.Extensions;
using mvc0826.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mvc0826
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region Configurarion Injection v1

            var appConfig = new AppSettingsJson(); // 請先定義 AppSettings 類別
            Configuration.Bind(appConfig);
            

            services.AddSingleton<AppSettingsJson>(appConfig);

            #endregion

            #region Configurarion Injection v2
            
            services.Configure<AppSettingsJson>(Configuration);

            #endregion

            #region Configuration Injection v3
            services.Configure<AppSettingsSubJson>(
                Configuration.GetSection("Sub"));

            #endregion

            #region DI 練習

            services.AddTransient<IAppSettingsTransient, AppSettings>();
           
            services.AddScoped<IAppSettingsScoped, AppSettings>();

            services.AddSingleton<IAppSettingsSingleton, AppSettings>();           

            #endregion

            #region 使用Session(建議不要用）

            services.AddDistributedMemoryCache();
            
            services.AddSession(options => { });

            #endregion

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            #region default

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            
            app.UseCookiePolicy();

            app.UseSession();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });      

            #endregion
           
            #region Use app.Use 與 Middleware
             
//            app.Use(async (context, next) =>
//            {
//                await context.Response.WriteAsync("hello Use 1 In !"+"\r\n");
//                await next();
//                await context.Response.WriteAsync("hello Use 1 Out !"+"\r\n");
//            });
//            
//            app.Use(async (context, next) =>
//            {
//                await context.Response.WriteAsync("hello Use 2 In !"+"\r\n");
//                await next();
//                await context.Response.WriteAsync("hello Use 2 Out !"+"\r\n");
//            });
//            
//            app.Use(async (context, next) =>
//            {
//                await context.Response.WriteAsync("hello Use 3 In !"+"\r\n");
//                if (context.Request.QueryString.HasValue)
//                {
//                    await context.Response.WriteAsync(context.Request.QueryString.Value+"\r\n");
//                }
//                else
//                {
//                    await next();
//                }
//
//                await context.Response.WriteAsync("hello Use 3 Out !"+"\r\n");
//            });
//            
//            app.Run(async (context) => { await context.Response.WriteAsync("Blackie !"+"\r\n"); });

            #endregion

            #region Use Middleware class 

//            app.UseCustomerMiddleware();

            #endregion
        }
    }
}

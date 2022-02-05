using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using _1262228_Arosh_NGJs.Data;

namespace _1262228_Arosh_NGJs
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
            //services.AddControllersWithViews();

            //Added by Arosh

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddCors(o => o.AddPolicy("AppPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            //Added by Arosh
            services.AddDbContext<NgDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyProjectJs_DbCon")));
        





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            //added by Arosh

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/Pages/index.html";
                    context.Response.StatusCode = 200;
                    await next();
                }
            });


            //added by Arosh

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("/Pages/index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            app.UseFileServer(enableDirectoryBrowsing: false);
            app.UseMvc();









        }

    }
}

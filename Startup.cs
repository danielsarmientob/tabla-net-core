using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using prueba.Models;
using MySql.Data;
using MySqlConnector;

namespace prueba
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddAuthorization();
            // services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IAmigoAlmacen, MockAmigoRepositorio>();
             services.AddSingleton<IAlumnos, MockAlumno>();
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection("datasource=localhost;username=root;password=;database=sistema_fc"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Pregunta si el entorno  es de desarrollo
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else if(env.IsProduction() || env.IsStaging()){ 
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            // app.UseRouting();
            // app.UseAuthorization();
            //  app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapDefaultControllerRoute();
            // });


            // app.Run(async (context)=>
            // {
            //     await context.Response.WriteAsync("Hola");
            // });
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("hola", async context =>
            //     {
            //         await context.Response.WriteAsync("Hola");
            //     });
            // });
        }
    }
}

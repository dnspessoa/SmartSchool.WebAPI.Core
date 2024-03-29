using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartSchool.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI
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
            //add conexão sqlLite
            // services.AddDbContext<SmartContext>(
            //     context => context.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            // );

            //add conexão sqlServe
            services.AddDbContext<SmartContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            //Ignora referncias circulares
            services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //add injeção de dependencia, resolve a dependecia
            //'addScoped' Garante que so tenha um DataContext por requisição
            //services.AddScoped<SmartContext, SmartContext>();

            //add serviço autoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IRepository, Repository>();      

            //Versionamento API
            // services.AddVersionedApiExplorer(opt => 
            // {
            //     opt.GroupNameFormat = "'v'VVV";
            //     opt.SubstituteApiVersionInUrl = true;
            // })
            // .AddApiVersioning(opt => 
            // {
            //     opt.AssumeDefaultVersionWhenUnspecified = true;
            //     opt.DefaultApiVersion = new ApiVersion(1, 0);
            //     opt.ReportApiVersions = true;
            // });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartSchool.WebAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSchool.WebAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using QuiEstCeAppli.Config;
using QuiEstCeAppli.Repositories;
using QuiEstCeAppli.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiEstCeAppli
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
            // Settings
            services.Configure<QuiEstCeDatabaseSettings>(Configuration.GetSection(nameof(QuiEstCeDatabaseSettings)));
            services.AddSingleton<IQuiEstCeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<QuiEstCeDatabaseSettings>>().Value);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            // Personnages
            services.AddSingleton<PersonnageRepository, PersonnageRepository>();
            services.AddSingleton<PersonnageService, PersonnageService>();

            // Question Reponse
            services.AddSingleton<QuestionReponseRepository, QuestionReponseRepository>();
            services.AddSingleton<QuestionReponseService, QuestionReponseService>();

            // Controllers
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuiEstCeAppli", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuiEstCeAppli v1"));
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

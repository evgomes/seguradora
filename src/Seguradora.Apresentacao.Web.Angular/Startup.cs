using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seguradora.Dominio.Repositorios;
using Seguradora.Dominio.Repositorios.Seguros;
using Seguradora.Dominio.Sevicos.Seguros;
using Seguradora.Persistencia.EF.Contextos;
using Seguradora.Persistencia.EF.Repositorios;
using Seguradora.Persistencia.EF.Repositorios.Seguros;
using Seguradora.Servicos.Seguros;

namespace Seguradora.Apresentacao.Web.Angular
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddDbContext<SeguradoraDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("SeguradoraDbContext"), opt =>
                {
                    opt.MigrationsAssembly(typeof(SeguradoraDbContext).Assembly.FullName);
                });
            });
            */

            services.AddDbContext<SeguradoraDbContext>(options => options.UseInMemoryDatabase("seguradora"));

            services.AddScoped<IRepositorioSeguros, RepositorioSeguros>();
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();

            services.AddScoped<IServicoSeguros, ServicoSeguros>();

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
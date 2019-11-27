using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatalogoCervejas.Aplicacao.AutoMapper;
using CatalogoCervejas.Aplicacao.Interfaces;
using CatalogoCervejas.Aplicacao.Servico;
using CatalogoCervejas.Infra.Dados.Contexto;
using CatalogoCervejas.Infra.Dados.Interfaces;
using CatalogoCervejas.Infra.Dados.Repositorio;
using CatalogoCervejas.Servico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CatalogoCervejas
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
            //AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToDomainMappingProfile());
                mc.AddProfile(new DomainToViewModelMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Repositórios
            services.AddScoped<IIngredienteRepositorio, IngredienteRepositorio>();
            services.AddScoped<ICervejaRepositorio, CervejaRepositorio>();
            services.AddScoped<IReceitaRepositorio, ReceitaRepositorio>();

            //Servicos
            services.AddScoped<IIngredienteServico, IngredienteServico>();
            services.AddScoped<ICervejaServico, CervejaServico>();
            services.AddScoped<IReceitaServico, ReceitaServico>();

            //DBContext
            services.AddDbContext<SqlServerContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:BancoSql"]));

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                    options.AllowAnyOrigin();
                }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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

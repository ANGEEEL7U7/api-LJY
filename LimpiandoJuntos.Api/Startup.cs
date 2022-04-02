using FluentValidation;
using LimpiandoJuntos.Application.Services;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;
using LimpiandoJuntos.Infrastructure;
using LimpiandoJuntos.Infrastructure.Data;
using LimpiandoJuntos.Infrastructure.Repositories;
using LimpiandoJuntos.Infrastructure.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LimpiandoJuntos.Api
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
            services.AddControllers();
            services.AddDbContext<LimpiandoJuntosDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BdRemota")).UseLazyLoadingProxies()
            );
            services.AddScoped<IMotivoRepository, MotivoRepository>();
            services.AddScoped<IMotivoService, MotivoService>();
            services.AddScoped<IDenunciaRepository, DenunciaRepository>();
            services.AddScoped<IDenunciaService, DenunciaService>();
            services.AddScoped<IUbicacionRepository, UbicacionRepository>();
            services.AddScoped<IUbicacionService, UbicacionService>();
            services.AddScoped<IPuntoDeInteresService, PuntoDeInteresService>();
            services.AddScoped<IPuntoDeInteresRepository, PuntodeInteresRepository>();
            services.AddScoped<IValidator<DenunciaRequest>, DenunciaRequestValidator>();
            services.AddScoped<IValidator<Ubicacion>, UbicacionValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LimpiandoJuntos.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LimpiandoJuntos.Api v1"));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
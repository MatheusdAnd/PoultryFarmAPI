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
using Microsoft.EntityFrameworkCore;
using PoultryApplication.Contratos;
using PoultryApplication;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;
using PoultryPersistence;

namespace PoultryAPI
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
            string msSqlConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextPool<PoultryContext>(
                options => options.UseSqlServer(msSqlConnection));
            services.AddControllers()
                    .AddNewtonsoftJson(
                        x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClientePersist, ClientePersist>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoPersist, ProdutoPersist>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoPersist, PedidoPersist>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoPersist, EnderecoPersist>();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PoultryAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PoultryAPI v1"));
                app.UseHttpsRedirection();
            }            

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

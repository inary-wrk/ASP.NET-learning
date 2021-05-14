using MetricsAgent.Models.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Controllers;
using MediatR;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Configuration;
using MetricsAgent.Models.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Data.SQLite;
using Mapster;
using System.Linq.Expressions;

namespace MetricsAgent
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
            services.AddMediatR(typeof(Startup));
            services.Configure<DBSettings>(Configuration.GetSection(DBSettings.DATA_BASE_SETTINGS));
            services.AddScoped<IMetricsRepository<CPUMetric>, CPUMetricsSQLiteDB>();
            services.AddScoped<IMetricsRepository<DotNetMetric>, DotNetMetricsSQLiteDB>();
            services.AddScoped<IMetricsRepository<HardDriveMetric>, HardDriveMetricsSQLiteDB>();
            services.AddScoped<IMetricsRepository<NetworkMetric>, NetworkMetricsSQLiteDB>();
            services.AddScoped<IMetricsRepository<RAMMetric>, RAMMetricsSQLiteDB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              IOptions<DBSettings> dataBaseSettings,
                              IMediator mediator
                             )
        {
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
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

            SQLiteConfigure configureSQLite = new(dataBaseSettings);
            configureSQLite.PrepareSchema();
            FillDataBase fillDataBase = new(mediator);
            fillDataBase.FillMetricsDataBase();
        }

    }
}
// TODO: stronginject(SG controllers inject)
// TODO: FluentValidation

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
using FluentValidation.AspNetCore;
using FluentValidation;
using MetricsAgent.Controllers.Dto;
using MetricsAgent.Validators;
using MetricsAgent.Mediatr.PipelineBehaviours;
using Dapper;
using MetricsAgent.DAL.Handlers;
using FluentMigrator.Runner;
using Quartz.Spi;
using MetricsAgent.Models.Application;
using Quartz;
using Quartz.Impl;
using MetricsAgent.Models.Application.Jobs;

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
            services.AddControllers().AddFluentValidation();
            services.AddTransient<IValidator<DateTimeRangeRequestDto>, DateTimeRangeRequestDtoValidator>();
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            //DB
            services.Configure<DBSettings>(Configuration.GetSection(DBSettings.DATA_BASE_SETTINGS));
            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString(Configuration.GetSection("DataBaseSettings")["SQLiteConnection"])
                .ScanIn(typeof(Startup).Assembly).For.Migrations())
                .AddLogging(lo => lo.AddFluentMigratorConsole());

            services.AddScoped<IMetricsQueryRepository<CPUMetric>, CPUMetricsSQLiteDB>();
            services.AddScoped<IMetricsQueryRepository<DotNetMetric>, DotNetMetricsSQLiteDB>();
            services.AddScoped<IMetricsQueryRepository<HardDriveMetric>, HardDriveMetricsSQLiteDB>();
            services.AddScoped<IMetricsQueryRepository<NetworkMetric>, NetworkMetricsSQLiteDB>();
            services.AddScoped<IMetricsQueryRepository<RAMMetric>, RAMMetricsSQLiteDB>();
            services.AddScoped<IMetricsCommandRepository<CPUMetric>, CPUMetricsSQLiteDB>();
            services.AddScoped<IMetricsCommandRepository<DotNetMetric>, DotNetMetricsSQLiteDB>();
            services.AddScoped<IMetricsCommandRepository<HardDriveMetric>, HardDriveMetricsSQLiteDB>();
            services.AddScoped<IMetricsCommandRepository<NetworkMetric>, NetworkMetricsSQLiteDB>();
            services.AddScoped<IMetricsCommandRepository<RAMMetric>, RAMMetricsSQLiteDB>();
            //Quartz
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              IMigrationRunner migrationRunner
                             )
        {
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

            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();
            SqlMapper.RemoveTypeMap(typeof(DateTimeOffset));
            SqlMapper.AddTypeHandler(typeof(DateTimeOffset), DateTimeOffsetHandler.Default);
            migrationRunner.MigrateUp();
        }
    }
}
// TODO: stronginject(SG controllers inject)

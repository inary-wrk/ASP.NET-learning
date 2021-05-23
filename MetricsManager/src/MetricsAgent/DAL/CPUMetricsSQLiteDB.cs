using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;
using MetricsAgent.DAL.Configuration;
using Dapper;
using MetricsAgent.DAL.Handlers;
using Microsoft.AspNetCore.Html;
using System.Data;

namespace MetricsAgent.DAL
{
    public class CPUMetricsSQLiteDB : IMetricsQueryRepository<CPUMetric>, IMetricsCommandRepository<CPUMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public CPUMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsCommandRepository<CPUMetric>.CreateMetric(CPUMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Execute($@"INSERT INTO CPUMetrics(DateTime, CpuUsage)
                                    VALUES(@DateTime, @CpuUsage)", metric);
        }

        IReadOnlyCollection<CPUMetric> IMetricsQueryRepository<CPUMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            return connection.Query<CPUMetric>(@$"SELECT * FROM CPUMetrics
                                                    WHERE DateTime 
                                                    BETWEEN @from AND @to",
                                                    new { from, to }).AsList();
        }
    }
}

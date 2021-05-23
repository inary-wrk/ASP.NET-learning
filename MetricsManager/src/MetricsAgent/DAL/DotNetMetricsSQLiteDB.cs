using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;
using MetricsAgent.DAL.Configuration;
using Dapper;

namespace MetricsAgent.DAL
{
    public class DotNetMetricsSQLiteDB : IMetricsQueryRepository<DotNetMetric>, IMetricsCommandRepository<DotNetMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public DotNetMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsCommandRepository<DotNetMetric>.CreateMetric(DotNetMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Execute($@"INSERT INTO {_dataBaseSettings.Value.DotNetTableName}(DateTime, Something)
                                    VALUES(@DateTime, @Something)", metric);
        }

        IReadOnlyCollection<DotNetMetric> IMetricsQueryRepository<DotNetMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);

            return connection.Query<DotNetMetric>(@$"SELECT * FROM {_dataBaseSettings.Value.DotNetTableName}
                                                    WHERE DateTime 
                                                    BETWEEN @from AND @to",
                                                    new { from, to }).AsList();
        }
    }
}

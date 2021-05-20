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
    public class HardDriveMetricsSQLiteDB : IMetricsQueryRepository<HardDriveMetric>, IMetricsCommandRepository<HardDriveMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public HardDriveMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsCommandRepository<HardDriveMetric>.CreateMetric(HardDriveMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Execute($@"INSERT INTO {_dataBaseSettings.Value.HardDriveTableName}(DateTime, Something)
                                    VALUES(@DateTime, @Something)", metric);
        }

        IReadOnlyCollection<HardDriveMetric> IMetricsQueryRepository<HardDriveMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            return connection.Query<HardDriveMetric>(@$"SELECT * FROM {_dataBaseSettings.Value.HardDriveTableName}
                                                    WHERE DateTime 
                                                    BETWEEN @from AND @to",
                                                    new { from, to }).AsList();
        }
    }
}

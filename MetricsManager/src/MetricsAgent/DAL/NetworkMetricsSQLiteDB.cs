using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MetricsAgent.DAL.Configuration;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;

namespace MetricsAgent.DAL
{
    public class NetworkMetricsSQLiteDB : IMetricsQueryRepository<NetworkMetric>, IMetricsCommandRepository<NetworkMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public NetworkMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsCommandRepository<NetworkMetric>.CreateMetric(NetworkMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Execute($@"INSERT INTO {_dataBaseSettings.Value.NetworkTableName}(DateTime, Something)
                                    VALUES(@DateTime, @Something)", metric);
        }

        IReadOnlyCollection<NetworkMetric> IMetricsQueryRepository<NetworkMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            return connection.Query<NetworkMetric>(@$"SELECT * FROM {_dataBaseSettings.Value.NetworkTableName}
                                                    WHERE DateTime 
                                                    BETWEEN @from AND @to",
                                                    new { from, to }).AsList();
        }
    }
}

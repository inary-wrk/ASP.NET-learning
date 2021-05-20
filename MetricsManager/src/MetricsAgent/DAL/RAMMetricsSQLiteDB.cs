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
    public class RAMMetricsSQLiteDB : IMetricsQueryRepository<RAMMetric>, IMetricsCommandRepository<RAMMetric>
    {

        private readonly IOptions<DBSettings> _dataBaseSettings;

        public RAMMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsCommandRepository<RAMMetric>.CreateMetric(RAMMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Execute($@"INSERT INTO {_dataBaseSettings.Value.RAMTableName}(DateTime, Something)
                                    VALUES(@DateTime, @Something)", metric);
        }

        IReadOnlyCollection<RAMMetric> IMetricsQueryRepository<RAMMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            return connection.Query<RAMMetric>(@$"SELECT * FROM {_dataBaseSettings.Value.RAMTableName}
                                                    WHERE DateTime 
                                                    BETWEEN @from AND @to",
                                                     new { from, to }).AsList();
        }
    }
}

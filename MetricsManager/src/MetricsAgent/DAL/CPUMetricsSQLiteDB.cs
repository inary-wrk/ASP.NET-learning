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
            connection.Open();
            connection.Execute()
            using var command = new SQLiteCommand(connection);
            command.CommandText = $@"
                                    INSERT INTO {_dataBaseSettings.Value.CPUTableName}(unixTime, value)
                                    VALUES(@unixTime, @value)";

            command.Parameters.AddWithValue("@unixTime", metric.DateTime.ToUnixTimeSeconds());
            command.Parameters.AddWithValue("@value", metric.Something);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        IReadOnlyCollection<CPUMetric> IMetricsQueryRepository<CPUMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {

            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            return connection.Query<CPUMetric>(@$"SELECT * FROM {_dataBaseSettings.Value.CPUTableName} 
                                                      WHERE unixTime 
                                                      BETWEEN @from AND @to", (from, to)).AsList();
            //using var command = new SQLiteCommand(connection);
            //command.CommandText = @$"
            //                        SELECT * 
            //                        FROM {_dataBaseSettings.Value.CPUTableName}
            //                        WHERE unixTime 
            //                        BETWEEN {from.ToUnixTimeSeconds()} AND {to.ToUnixTimeSeconds()}";

            //List<CPUMetric> metricsList = new();
            //using (SQLiteDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        metricsList.Add(
            //            new CPUMetric
            //            {
            //                DateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(0)),
            //                Something = reader.GetInt32(1)
            //            });
            //    }
            //}
            //return metricsList;
        }
    }
}

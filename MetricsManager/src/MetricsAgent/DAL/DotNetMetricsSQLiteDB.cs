using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;
using MetricsAgent.DAL.Configuration;

namespace MetricsAgent.DAL
{
    public class DotNetMetricsSQLiteDB : IMetricsRepository<DotNetMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public DotNetMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsRepository<DotNetMetric>.Create(DotNetMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = $@"
                                    INSERT INTO {_dataBaseSettings.Value.DotNetTableName}(unixTime, value)
                                    VALUES(@unixTime, @value)";

            command.Parameters.AddWithValue("@unixTime", metric.DateTime.ToUnixTimeSeconds());
            command.Parameters.AddWithValue("@value", metric.Something);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        IReadOnlyCollection<DotNetMetric> IMetricsRepository<DotNetMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = @$"
                                    SELECT * 
                                    FROM {_dataBaseSettings.Value.DotNetTableName}
                                    WHERE unixTime 
                                    BETWEEN {from.ToUnixTimeSeconds()} AND {to.ToUnixTimeSeconds()}";

            List<DotNetMetric> metricsList = new();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    metricsList.Add(
                        new DotNetMetric
                        {
                            DateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(0)),
                            Something = reader.GetString(1)
                        });
                }
            }
            return metricsList;
        }
    }
}

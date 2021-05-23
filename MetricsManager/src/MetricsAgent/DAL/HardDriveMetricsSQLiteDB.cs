using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;
using MetricsAgent.DAL.Configuration;

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
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = $@"
                                    INSERT INTO {_dataBaseSettings.Value.HardDriveTableName}(unixTime, value)
                                    VALUES(@unixTime, @value)";

            command.Parameters.AddWithValue("@unixTime", metric.DateTime.ToUnixTimeSeconds());
            command.Parameters.AddWithValue("@value", metric.Something);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        IReadOnlyCollection<HardDriveMetric> IMetricsQueryRepository<HardDriveMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = @$"
                                    SELECT * 
                                    FROM {_dataBaseSettings.Value.HardDriveTableName}
                                    WHERE unixTime 
                                    BETWEEN {from.ToUnixTimeSeconds()} AND {to.ToUnixTimeSeconds()}";

            List<HardDriveMetric> metricsList = new();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    metricsList.Add(
                        new HardDriveMetric
                        {
                            DateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(0)),
                            Something = reader.GetInt32(1)
                        });
                }
            }
            return metricsList;
        }
    }
}

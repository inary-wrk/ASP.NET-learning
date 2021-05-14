using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;
using MetricsAgent.DAL.Configuration;

namespace MetricsAgent.DAL
{
    public class CPUMetricsSQLiteDB : IMetricsRepository<CPUMetric>
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public CPUMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsRepository<CPUMetric>.Create(CPUMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = $@"
                                    INSERT INTO cpumetrics(unixTime, value)
                                    VALUES(@unixTime, @value)";

            command.Parameters.AddWithValue("@unixTime", metric.DateTime.ToUnixTimeSeconds());
            command.Parameters.AddWithValue("@value", metric.Something);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        IReadOnlyCollection<CPUMetric> IMetricsRepository<CPUMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = @$"
                                    SELECT * 
                                    FROM cpumetrics
                                    WHERE unixTime 
                                    BETWEEN {from.ToUnixTimeSeconds()} AND {to.ToUnixTimeSeconds()}";

            List<CPUMetric> cpuMetricsList = new();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cpuMetricsList.Add(
                        new CPUMetric
                        {
                            DateTime = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64(0)),
                            Something = reader.GetInt32(1)
                        });
                }
            }
            return cpuMetricsList;
        }
    }
}

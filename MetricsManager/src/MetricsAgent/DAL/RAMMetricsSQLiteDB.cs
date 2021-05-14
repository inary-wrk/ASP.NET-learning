using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DAL.Configuration;
using MetricsAgent.Models.Domain.Entities;
using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Options;

namespace MetricsAgent.DAL
{
    public class RAMMetricsSQLiteDB : IMetricsRepository<RAMMetric>
    {

        private readonly IOptions<DBSettings> _dataBaseSettings;

        public RAMMetricsSQLiteDB(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        void IMetricsRepository<RAMMetric>.Create(RAMMetric metric)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = $@"
                                    INSERT INTO {_dataBaseSettings.Value.RAMTableName}(unixTime, value)
                                    VALUES(@unixTime, @value)";

            command.Parameters.AddWithValue("@unixTime", metric.DateTime.ToUnixTimeSeconds());
            command.Parameters.AddWithValue("@value", metric.Something);
            command.Prepare();
            command.ExecuteNonQuery();
        }

        IReadOnlyCollection<RAMMetric> IMetricsRepository<RAMMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            command.CommandText = @$"
                                    SELECT * 
                                    FROM {_dataBaseSettings.Value.RAMTableName}
                                    WHERE unixTime 
                                    BETWEEN {from.ToUnixTimeSeconds()} AND {to.ToUnixTimeSeconds()}";

            List<RAMMetric> metricsList = new();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    metricsList.Add(
                        new RAMMetric
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

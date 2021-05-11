using MetricsAgent.Models.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class SQLiteRepository<TMetric> : IMetricsQueryRepository<TMetric>, IMetricsCommandRepository<TMetric>
        where TMetric : class
    {
        public readonly IOptions<DBSettings> _settings;


        public SQLiteRepository(IOptions<DBSettings> settings)
        {
            _settings = settings;
        }

        bool IMetricsCommandRepository<TMetric>.Create(TMetric metric)
        {
            using (var connection = new SQLiteConnection(_settings.Value.SQLiteConnection))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @$"CREATE TABLE IF NOT EXISTS {typeof(TMetric).Name}(unixTime INT8 PRIMARY KEY,
                    value INT)";
                    command.ExecuteNonQuery();
                    command.CommandText = $"INSERT INTO {typeof(TMetric).Name}(unixTime, value) VALUES(@unixTime, @value)";
                    command.Parameters.AddWithValue("@unixTime", metric)
                }

            }
        }

        IReadOnlyCollection<TMetric> IMetricsQueryRepository<TMetric>.GetMetricsByTimePeriod(DateTimeOffset from, DateTimeOffset to)
        {
            var connectionString = new SQLiteConnectionStringBuilder(_settings.Value.SQLiteConnection)
            {
                ReadOnly = true
            }.ToString();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                }

            }

        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = $"DROP TABLE IF EXISTS {typeof(TMetric).Name}";
                command.ExecuteNonQuery();
                command.CommandText = @$"CREATE TABLE IF NOT EXISTS {typeof(TMetric).Name}(id INTEGER PRIMARY KEY,
                    value INT, time INT)";


            }
        }
    }
}

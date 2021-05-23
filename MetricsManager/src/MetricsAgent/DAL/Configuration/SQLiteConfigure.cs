using System;
using System.Data.SQLite;
using Dapper;
using MetricsAgent.DAL.Handlers;
using Microsoft.Extensions.Options;

namespace MetricsAgent.DAL.Configuration
{
    public class SQLiteConfigure
    {
        private readonly IOptions<DBSettings> _dataBaseSettings;

        public SQLiteConfigure(IOptions<DBSettings> dataBaseSettings)
        {
            _dataBaseSettings = dataBaseSettings;
        }

        public void PrepareSchema()
        {
            using var connection = new SQLiteConnection(_dataBaseSettings.Value.SQLiteConnection);
            connection.Open();
            using var command = new SQLiteCommand(connection);
            CPUMetricsPrepare(command);
            DotNetMetricsPrepare(command);
            HardDriveMetricsPrepare(command);
            NetworkMetricsPrepare(command);
            RAMMetricsPrepare(command);
            ConfigureSqliteMapper();
        }

        private void ConfigureSqliteMapper()
        {
            SqlMapper.RemoveTypeMap(typeof(DateTimeOffset));
            SqlMapper.AddTypeHandler(typeof(DateTimeOffset), DateTimeOffsetHandler.Default);
        }

        private void CPUMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.CPUTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.CPUTableName}(DateTime INTEGER PRIMARY KEY,
                    Something INT)";
            command.ExecuteNonQuery();
        }

        private void DotNetMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.DotNetTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.DotNetTableName}(DateTime INTEGER PRIMARY KEY,
                    Something TEXT)";
            command.ExecuteNonQuery();
        }

        private void HardDriveMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.HardDriveTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.HardDriveTableName}(DateTime INTEGER PRIMARY KEY,
                    Something INT)";
            command.ExecuteNonQuery();
        }

        private void NetworkMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.NetworkTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.NetworkTableName}(DateTime INTEGER PRIMARY KEY,
                    Something INT)";
            command.ExecuteNonQuery();
        }

        private void RAMMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.RAMTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.RAMTableName}(DateTime INTEGER PRIMARY KEY,
                    Something INT)";
            command.ExecuteNonQuery();
        }
    }
}

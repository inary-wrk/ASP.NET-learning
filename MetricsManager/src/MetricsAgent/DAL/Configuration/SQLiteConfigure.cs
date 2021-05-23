using System.Data.SQLite;
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
        }

        private void CPUMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.CPUTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.CPUTableName}(unixTime INTEGER PRIMARY KEY,
                    value INT)";
            command.ExecuteNonQuery();
        }

        private void DotNetMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.DotNetTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.DotNetTableName}(unixTime INTEGER PRIMARY KEY,
                    value TEXT)";
            command.ExecuteNonQuery();
        }

        private void HardDriveMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.HardDriveTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.HardDriveTableName}(unixTime INTEGER PRIMARY KEY,
                    value INT)";
            command.ExecuteNonQuery();
        }

        private void NetworkMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.NetworkTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.NetworkTableName}(unixTime INTEGER PRIMARY KEY,
                    value INT)";
            command.ExecuteNonQuery();
        }

        private void RAMMetricsPrepare(SQLiteCommand command)
        {
            command.CommandText = $@"DROP TABLE IF EXISTS {_dataBaseSettings.Value.RAMTableName}";
            command.ExecuteNonQuery();
            command.CommandText = @$"CREATE TABLE {_dataBaseSettings.Value.RAMTableName}(unixTime INTEGER PRIMARY KEY,
                    value INT)";
            command.ExecuteNonQuery();
        }
    }
}

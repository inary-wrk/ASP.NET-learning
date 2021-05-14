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
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = $@"DROP TABLE IF EXISTS cpumetrics";
                command.ExecuteNonQuery();
                command.CommandText = @$"CREATE TABLE cpumetrics(unixTime INTEGER PRIMARY KEY,
                    value INT)";
                command.ExecuteNonQuery();
            }
        }

    }
}

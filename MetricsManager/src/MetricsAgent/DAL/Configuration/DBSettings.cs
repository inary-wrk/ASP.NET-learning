using System.Collections.Generic;

namespace MetricsAgent.DAL.Configuration
{
    public class DBSettings
    {
        public const string DATA_BASE_SETTINGS = "DataBaseSettings";
        public string SQLiteConnection { get; set; }
        public string CPUTableName { get { return "CPUMetrics"; } }
        public string DotNetTableName { get { return "DotNetMetrics"; } }
        public string HardDriveTableName { get { return "HardDriveMetrics"; } }
        public string NetworkTableName { get { return "NetworkMetrics"; } }
        public string RAMTableName { get { return "RAMMetrics"; } }
    }
}

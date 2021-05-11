using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class DBSettings
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public string SQLiteConnection { get; set; } 
    }
}

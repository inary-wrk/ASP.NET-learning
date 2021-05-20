using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MetricsAgent.DAL.Handlers
{
    public class DateTimeOffsetHandler : SqlMapper.TypeHandler<DateTimeOffset>
    {
        public static readonly SqlMapper.ITypeHandler Default = new DateTimeOffsetHandler();
        private DateTimeOffsetHandler() { }
        public override DateTimeOffset Parse(object value)
        => DateTimeOffset.FromUnixTimeSeconds((long)value);

        public override void SetValue(IDbDataParameter parameter, DateTimeOffset value)
        {
            parameter.DbType = DbType.Int64;
            parameter.Value = value.ToUnixTimeSeconds();
        }
    }
}

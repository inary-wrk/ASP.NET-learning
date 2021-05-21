using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace MetricsAgent.DAL.Migrations
{
    [Migration(20210520)]
    public class FirstMigrationSQlite : Migration
    {
        public override void Up()
        {
            Create.Table("CPUMetrics")
                .WithColumn("DateTime").AsInt64().PrimaryKey()
                .WithColumn("Something").AsInt32();
        }

        public override void Down()
        {
            Delete.Table("CPUMetrics");
        }

    }
}

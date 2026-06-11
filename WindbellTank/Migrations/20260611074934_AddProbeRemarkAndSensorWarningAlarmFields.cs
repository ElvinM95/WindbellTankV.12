using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindbellTank.Migrations
{
    /// <inheritdoc />
    public partial class AddProbeRemarkAndSensorWarningAlarmFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'AlarmValue' AND Object_ID = Object_ID(N'WindbellSensorSettings'))
                BEGIN
                    ALTER TABLE [WindbellSensorSettings] ADD [AlarmValue] nvarchar(20) NOT NULL DEFAULT N'';
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'WarningValue' AND Object_ID = Object_ID(N'WindbellSensorSettings'))
                BEGIN
                    ALTER TABLE [WindbellSensorSettings] ADD [WarningValue] nvarchar(20) NOT NULL DEFAULT N'';
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'Remark' AND Object_ID = Object_ID(N'WindbellProbeSettings'))
                BEGIN
                    ALTER TABLE [WindbellProbeSettings] ADD [Remark] nvarchar(200) NOT NULL DEFAULT N'';
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlarmValue",
                table: "WindbellSensorSettings");

            migrationBuilder.DropColumn(
                name: "WarningValue",
                table: "WindbellSensorSettings");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "WindbellProbeSettings");
        }
    }
}

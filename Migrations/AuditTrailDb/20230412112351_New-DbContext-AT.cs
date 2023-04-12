using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditLoggerPoc.Migrations.AuditTrailDb
{
    /// <inheritdoc />
    public partial class NewDbContextAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditTrails",
                table: "AuditTrails");

            migrationBuilder.RenameTable(
                name: "AuditTrails",
                newName: "AuditTrailData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditTrailData",
                table: "AuditTrailData",
                column: "TrailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditTrailData",
                table: "AuditTrailData");

            migrationBuilder.RenameTable(
                name: "AuditTrailData",
                newName: "AuditTrails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditTrails",
                table: "AuditTrails",
                column: "TrailId");
        }
    }
}

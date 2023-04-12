using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditLoggerPoc.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditTrailtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    TrailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    oldValues = table.Column<string>(type: "TEXT", nullable: false),
                    newValues = table.Column<string>(type: "TEXT", nullable: false),
                    affectedColumns = table.Column<string>(type: "TEXT", nullable: false),
                    primaryKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.TrailId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrails");
        }
    }
}

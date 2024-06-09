using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reboot.DB.Migrations
{
    /// <inheritdoc />
    public partial class Addedseriesdbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FabricId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneSeries_PhoneFabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "PhoneFabrics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneSeries_FabricId",
                table: "PhoneSeries",
                column: "FabricId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneSeries");
        }
    }
}

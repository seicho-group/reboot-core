using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reboot.DB.Migrations
{
    /// <inheritdoc />
    public partial class Addedinitialmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeriesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneModels_PhoneSeries_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "PhoneSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneModelModifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModelModifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneModelModifications_PhoneModels_PhoneModelId",
                        column: x => x.PhoneModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    ReplicaPrice = table.Column<int>(type: "integer", nullable: false),
                    BudgetReplicaPrice = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferPrices_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferPrices_PhoneModelModifications_ModelId",
                        column: x => x.ModelId,
                        principalTable: "PhoneModelModifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferPrices_ModelId",
                table: "OfferPrices",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferPrices_OfferId",
                table: "OfferPrices",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModelModifications_PhoneModelId",
                table: "PhoneModelModifications",
                column: "PhoneModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_SeriesId",
                table: "PhoneModels",
                column: "SeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferPrices");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "PhoneModelModifications");

            migrationBuilder.DropTable(
                name: "PhoneModels");
        }
    }
}

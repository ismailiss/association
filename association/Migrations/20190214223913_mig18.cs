using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace association.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FactureDe",
                table: "Factures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "FacturesGeneree",
                columns: table => new
                {
                    FactureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFactures = table.Column<DateTime>(nullable: false),
                    DateGeneration = table.Column<DateTime>(nullable: false),
                    FactureDE = table.Column<DateTime>(nullable: false),
                    NombreFacturesGenerees = table.Column<int>(nullable: false),
                    AssociationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturesGeneree", x => x.FactureID);
                    table.ForeignKey(
                        name: "FK_FacturesGeneree_Associations_AssociationID",
                        column: x => x.AssociationID,
                        principalTable: "Associations",
                        principalColumn: "AssociationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturesGeneree_AssociationID",
                table: "FacturesGeneree",
                column: "AssociationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturesGeneree");

            migrationBuilder.DropColumn(
                name: "FactureDe",
                table: "Factures");
        }
    }
}

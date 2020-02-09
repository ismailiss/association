using Microsoft.EntityFrameworkCore.Migrations;

namespace association.Migrations
{
    public partial class mig19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreFacturesGenerees",
                table: "FacturesGeneree");

            migrationBuilder.RenameColumn(
                name: "FactureDE",
                table: "FacturesGeneree",
                newName: "FactureDe");

            migrationBuilder.RenameColumn(
                name: "FactureID",
                table: "FacturesGeneree",
                newName: "FacturesGenereeID");

            migrationBuilder.AddColumn<int>(
                name: "FacturesGenereeID1",
                table: "FacturesGeneree",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturesGenereeID",
                table: "Factures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacturesGeneree_FacturesGenereeID1",
                table: "FacturesGeneree",
                column: "FacturesGenereeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_FacturesGenereeID",
                table: "Factures",
                column: "FacturesGenereeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_FacturesGeneree_FacturesGenereeID",
                table: "Factures",
                column: "FacturesGenereeID",
                principalTable: "FacturesGeneree",
                principalColumn: "FacturesGenereeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturesGeneree_FacturesGeneree_FacturesGenereeID1",
                table: "FacturesGeneree",
                column: "FacturesGenereeID1",
                principalTable: "FacturesGeneree",
                principalColumn: "FacturesGenereeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_FacturesGeneree_FacturesGenereeID",
                table: "Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturesGeneree_FacturesGeneree_FacturesGenereeID1",
                table: "FacturesGeneree");

            migrationBuilder.DropIndex(
                name: "IX_FacturesGeneree_FacturesGenereeID1",
                table: "FacturesGeneree");

            migrationBuilder.DropIndex(
                name: "IX_Factures_FacturesGenereeID",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "FacturesGenereeID1",
                table: "FacturesGeneree");

            migrationBuilder.DropColumn(
                name: "FacturesGenereeID",
                table: "Factures");

            migrationBuilder.RenameColumn(
                name: "FactureDe",
                table: "FacturesGeneree",
                newName: "FactureDE");

            migrationBuilder.RenameColumn(
                name: "FacturesGenereeID",
                table: "FacturesGeneree",
                newName: "FactureID");

            migrationBuilder.AddColumn<int>(
                name: "NombreFacturesGenerees",
                table: "FacturesGeneree",
                nullable: false,
                defaultValue: 0);
        }
    }
}

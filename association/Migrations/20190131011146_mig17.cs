using Microsoft.EntityFrameworkCore.Migrations;

namespace association.Migrations
{
    public partial class mig17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Tarif_TarifID",
                table: "Factures");

            migrationBuilder.AlterColumn<int>(
                name: "TarifID",
                table: "Factures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Tarif_TarifID",
                table: "Factures",
                column: "TarifID",
                principalTable: "Tarif",
                principalColumn: "TarifID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Tarif_TarifID",
                table: "Factures");

            migrationBuilder.AlterColumn<int>(
                name: "TarifID",
                table: "Factures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Tarif_TarifID",
                table: "Factures",
                column: "TarifID",
                principalTable: "Tarif",
                principalColumn: "TarifID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

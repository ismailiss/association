using Microsoft.EntityFrameworkCore.Migrations;

namespace association.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AssociationID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationID",
                table: "AspNetUsers",
                column: "AssociationID",
                principalTable: "Associations",
                principalColumn: "AssociationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AssociationID",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Associations_AssociationID",
                table: "AspNetUsers",
                column: "AssociationID",
                principalTable: "Associations",
                principalColumn: "AssociationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

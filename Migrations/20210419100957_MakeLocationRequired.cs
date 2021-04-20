using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshippClass.Migrations
{
    public partial class MakeLocationRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interns_Locations_locationId",
                table: "Interns");

            migrationBuilder.AlterColumn<int>(
                name: "locationId",
                table: "Interns",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interns_Locations_locationId",
                table: "Interns",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interns_Locations_locationId",
                table: "Interns");

            migrationBuilder.AlterColumn<int>(
                name: "locationId",
                table: "Interns",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Interns_Locations_locationId",
                table: "Interns",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

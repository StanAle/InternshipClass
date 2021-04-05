using Microsoft.EntityFrameworkCore.Migrations;

namespace InternshippClass.Migrations
{
    public partial class DbChangedToAutoIncrementId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfJoin",
                table: "Interns",
                newName: "RegistrationDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDateTime",
                table: "Interns",
                newName: "DateOfJoin");
        }
    }
}

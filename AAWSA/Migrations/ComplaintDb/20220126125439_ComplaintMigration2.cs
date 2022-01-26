using Microsoft.EntityFrameworkCore.Migrations;

namespace AAWSA.Migrations.ComplaintDb
{
    public partial class ComplaintMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Compliant_Type",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "caseType",
                table: "Complaints",
                newName: "CaseType");

            migrationBuilder.RenameColumn(
                name: "Wereda",
                table: "Complaints",
                newName: "Woreda");
            migrationBuilder.RenameColumn(
               name: "Fisrt_Name",
               table: "Complaints",
               newName: "First_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaseType",
                table: "Complaints",
                newName: "caseType");

            migrationBuilder.RenameColumn(
                name: "Woreda",
                table: "Complaints",
                newName: "Wereda");

            migrationBuilder.AddColumn<string>(
                name: "Compliant_Type",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.RenameColumn(
               name: "Fisrt_Name",
               table: "Complaints",
               newName: "First_Name");
        }
    }
}

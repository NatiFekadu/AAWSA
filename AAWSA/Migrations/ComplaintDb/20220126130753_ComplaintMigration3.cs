using Microsoft.EntityFrameworkCore.Migrations;

namespace AAWSA.Migrations.ComplaintDb
{
    public partial class ComplaintMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fisrt_Name",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "Complaints",
                newName: "First_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Complaints",
                newName: "Recipient");

            migrationBuilder.AddColumn<string>(
                name: "Fisrt_Name",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

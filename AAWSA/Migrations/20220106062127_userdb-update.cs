using Microsoft.EntityFrameworkCore.Migrations;

namespace AAWSA.Migrations
{
    public partial class userdbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "AspNetUsers",
                newName: "Branches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branches",
                table: "AspNetUsers",
                newName: "Branch");
        }
    }
}

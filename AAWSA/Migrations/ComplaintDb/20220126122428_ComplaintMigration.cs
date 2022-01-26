using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AAWSA.Migrations.ComplaintDb
{
    public partial class ComplaintMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fisrt_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branches = table.Column<int>(type: "int", nullable: false),
                    Special_Place_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    House_number = table.Column<int>(type: "int", nullable: false),
                    Phone_number = table.Column<int>(type: "int", nullable: false),
                    Subcity = table.Column<int>(type: "int", nullable: false),
                    Wereda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    caseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}

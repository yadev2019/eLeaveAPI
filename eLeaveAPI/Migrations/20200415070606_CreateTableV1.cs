using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eLeaveAPI.Migrations
{
    public partial class CreateTableV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    Topic = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: true),
                    endDate = table.Column<DateTime>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    statusId = table.Column<int>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Eventtype = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: true),
                    Updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Refers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    refCode = table.Column<int>(nullable: false),
                    refGroup = table.Column<string>(nullable: true),
                    refName = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: true),
                    Updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusName = table.Column<string>(nullable: true),
                    statusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    Holiday = table.Column<double>(nullable: false),
                    Sick = table.Column<double>(nullable: false),
                    Personal = table.Column<double>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: true),
                    Updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Provider = table.Column<string>(nullable: true),
                    Provider_Id = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    remember_token = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: true),
                    Updated_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Refers");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Usages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

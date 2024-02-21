using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF.Reserva.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserve");
        }
    }
}

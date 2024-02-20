using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF.Estabelecimento.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Local = table.Column<string>(type: "varchar(250)", nullable: false),
                    ImgURL = table.Column<string>(type: "varchar(250)", nullable: false),
                    Detail = table.Column<string>(type: "varchar(500)", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    QuantityPeople = table.Column<int>(type: "int", nullable: false),
                    NominatedAudience = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establishment");
        }
    }
}

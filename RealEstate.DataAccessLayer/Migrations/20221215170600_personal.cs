using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DataAccessLayer.Migrations
{
    public partial class personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personals", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personals");
        }
    }
}

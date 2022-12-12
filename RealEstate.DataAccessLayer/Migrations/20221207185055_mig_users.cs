using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DataAccessLayer.Migrations
{
    public partial class mig_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsersName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsersName",
                table: "Products",
                column: "UsersName");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_UsersName",
                table: "Products",
                column: "UsersName",
                principalTable: "User",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_UsersName",
                table: "Products");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsersName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UsersName",
                table: "Products");
        }
    }
}

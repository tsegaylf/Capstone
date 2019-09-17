using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_ServerProject.Migrations
{
    public partial class UsernameUnique2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IDX_Username",
                table: "Users",
                column: "Username",
                    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IDX_Username");

        }
    }
}

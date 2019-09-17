using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_ServerProject.Migrations
{
    public partial class ProductUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IDX_PrtNbr",
                table: "Products",
                column: "PrtNbr",
                    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropIndex(
            name: "IDX_PrtNbr");

        }
    }
}

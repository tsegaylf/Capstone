using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_ServerProject.Migrations
{
    public partial class VendorCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IDX_Code",
                table: "Vendors",
                column: "Code",
                    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropIndex(
            name: "IDX_Code");

        }
    }
}

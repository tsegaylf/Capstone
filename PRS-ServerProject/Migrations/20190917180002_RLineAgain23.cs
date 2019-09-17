using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_ServerProject.Migrations
{
    public partial class RLineAgain23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "RequestLines",
                            columns: table => new {
                                Id = table.Column<int>(nullable: false)
                                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                                ProductId = table.Column<int>(nullable: false),
                                RequestId = table.Column<int>(nullable: false),
                                Quantity = table.Column<int>(nullable: false),

                            },
                            constraints: table => {
                                table.PrimaryKey("PK_RequestLines", x => x.Id);

                                table.ForeignKey(
                                    name: "FK_RequestLines_Products_ProductId",
                                    column: x => x.ProductId,
                                    principalTable: "Products",
                                    principalColumn: "Id");

                                table.ForeignKey(
                         name: "FK_RequestLines_Request_RequestId",
                         column: x => x.RequestId,
                         principalTable: "Request",
                         principalColumn: "Id");
                            });

        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
            name: "RequestLines");

        }
    }
}

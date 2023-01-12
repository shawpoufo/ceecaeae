using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Artisanal.Services.ProductAPI.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "ImageURL", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "categorie1", "1.jpg", 15.0, "ChaiseBoisMassif" },
                    { 2, "categorie2", "2.jpg", 15.0, "RangementBoisMassif" },
                    { 3, "categorie1", "3.jpg", 15.0, "DecorArtis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

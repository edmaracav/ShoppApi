using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppApi.Migrations
{
    public partial class UpdateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Oid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "skus",
                columns: table => new
                {
                    Oid = table.Column<Guid>(nullable: false),
                    Inventory = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductOid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skus", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_skus_products_ProductOid",
                        column: x => x.ProductOid,
                        principalTable: "products",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SkuOid = table.Column<Guid>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    UnitValue = table.Column<double>(nullable: false),
                    CartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartProduct_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartProduct_skus_SkuOid",
                        column: x => x.SkuOid,
                        principalTable: "skus",
                        principalColumn: "Oid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_SkuOid",
                table: "CartProduct",
                column: "SkuOid");

            migrationBuilder.CreateIndex(
                name: "IX_skus_ProductOid",
                table: "skus",
                column: "ProductOid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "skus");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}

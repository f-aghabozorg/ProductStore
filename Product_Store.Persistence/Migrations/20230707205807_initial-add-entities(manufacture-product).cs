using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product_Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialaddentitiesmanufactureproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    ManufactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufactureFirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ManufactureLastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ManufactureEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ManufacturePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturePassword = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.ManufactureId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProduceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManufactureEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufactureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.ManufactureEmail, x.ProduceDate });
                    table.ForeignKey(
                        name: "FK_Product_Manufacture",
                        column: x => x.ManufactureId,
                        principalTable: "Manufactures",
                        principalColumn: "ManufactureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_ManufactureEmail",
                table: "Manufactures",
                column: "ManufactureEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureId",
                table: "Products",
                column: "ManufactureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Manufactures");
        }
    }
}

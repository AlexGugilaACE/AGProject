using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGWADProject.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TractionTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TractionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TractionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TractionTypeId",
                table: "Cars",
                column: "TractionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TractionType_TractionTypeId",
                table: "Cars",
                column: "TractionTypeId",
                principalTable: "TractionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TractionType_TractionTypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "TractionType");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TractionTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TractionTypeId",
                table: "Cars");
        }
    }
}

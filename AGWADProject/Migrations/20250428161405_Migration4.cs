using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGWADProject.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TractionType_TractionTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TractionType",
                table: "TractionType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType");

            migrationBuilder.RenameTable(
                name: "TractionType",
                newName: "TractionTypes");

            migrationBuilder.RenameTable(
                name: "FuelType",
                newName: "FuelTypes");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionTypeId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TractionTypes",
                table: "TractionTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionTypeId",
                table: "Cars",
                column: "TransmissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TractionTypes_TractionTypeId",
                table: "Cars",
                column: "TractionTypeId",
                principalTable: "TractionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionTypeId",
                table: "Cars",
                column: "TransmissionTypeId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TractionTypes_TractionTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_TransmissionTypes_TransmissionTypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TractionTypes",
                table: "TractionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.DropColumn(
                name: "TransmissionTypeId",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "TractionTypes",
                newName: "TractionType");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TractionType",
                table: "TractionType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType",
                column: "Id");

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
    }
}

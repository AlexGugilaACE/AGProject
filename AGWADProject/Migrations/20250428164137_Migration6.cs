using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGWADProject.Migrations
{
    /// <inheritdoc />
    public partial class Migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PersonId",
                table: "Cars",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Persons_PersonId",
                table: "Cars",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Persons_PersonId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PersonId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Cars");
        }
    }
}

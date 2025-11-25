using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGWADProject.Migrations
{
    /// <inheritdoc />
    public partial class migrationphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoPath",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoPath",
                table: "Posts");
        }
    }
}

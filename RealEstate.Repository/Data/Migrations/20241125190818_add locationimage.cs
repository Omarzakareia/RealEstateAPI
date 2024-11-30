using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class addlocationimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Locations");
        }
    }
}

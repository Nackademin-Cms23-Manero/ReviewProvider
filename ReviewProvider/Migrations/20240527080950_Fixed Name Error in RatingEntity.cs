using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewProvider.Migrations
{
    /// <inheritdoc />
    public partial class FixedNameErrorinRatingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarRatiing",
                table: "Ratings",
                newName: "StarRating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarRating",
                table: "Ratings",
                newName: "StarRatiing");
        }
    }
}

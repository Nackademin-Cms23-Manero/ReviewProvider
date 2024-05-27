using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewProvider.Migrations
{
    /// <inheritdoc />
    public partial class ChangesUsereIdtoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserReviews",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserReviews",
                newName: "UserId");
        }
    }
}

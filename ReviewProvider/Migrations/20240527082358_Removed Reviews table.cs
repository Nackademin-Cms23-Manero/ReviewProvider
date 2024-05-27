using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewProvider.Migrations
{
    /// <inheritdoc />
    public partial class RemovedReviewstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "UserReviews");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "UserReviews",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "UserReviews");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "UserReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafyVersion3.Migrations
{
    /// <inheritdoc />
    public partial class dasda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecyclingActivities_Users_Id",
                table: "RecyclingActivities");

            migrationBuilder.CreateIndex(
                name: "IX_RecyclingActivities_UserId",
                table: "RecyclingActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecyclingActivities_Users_UserId",
                table: "RecyclingActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecyclingActivities_Users_UserId",
                table: "RecyclingActivities");

            migrationBuilder.DropIndex(
                name: "IX_RecyclingActivities_UserId",
                table: "RecyclingActivities");

            migrationBuilder.AddForeignKey(
                name: "FK_RecyclingActivities_Users_Id",
                table: "RecyclingActivities",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafyVersion3.Migrations
{
    /// <inheritdoc />
    public partial class PointsAwarded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsAwarded",
                table: "RecyclingActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsAwarded",
                table: "RecyclingActivities");
        }
    }
}

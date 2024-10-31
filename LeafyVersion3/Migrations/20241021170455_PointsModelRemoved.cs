using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafyVersion3.Migrations
{
    /// <inheritdoc />
    public partial class PointsModelRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "RecyclingActivities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "RecyclingActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

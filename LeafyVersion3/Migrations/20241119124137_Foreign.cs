using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeafyVersion3.Migrations
{
    /// <inheritdoc />
    public partial class Foreign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RecyclingActivities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecyclingActivities");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class fixedpolyclinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolyclinicId",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PolyclinicId",
                table: "Schedules",
                column: "PolyclinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Polyclinics_PolyclinicId",
                table: "Schedules",
                column: "PolyclinicId",
                principalTable: "Polyclinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Polyclinics_PolyclinicId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_PolyclinicId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "PolyclinicId",
                table: "Schedules");
        }
    }
}

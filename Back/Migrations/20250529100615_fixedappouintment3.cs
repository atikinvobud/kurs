using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class fixedappouintment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Conclusions_ConclusionId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "ConclusionId",
                table: "Appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Conclusions_ConclusionId",
                table: "Appointments",
                column: "ConclusionId",
                principalTable: "Conclusions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Conclusions_ConclusionId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "ConclusionId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Conclusions_ConclusionId",
                table: "Appointments",
                column: "ConclusionId",
                principalTable: "Conclusions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

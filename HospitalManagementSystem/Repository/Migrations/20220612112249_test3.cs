using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Gender_GenderId",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Gender_GenderId",
                table: "Patient",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Gender_GenderId",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Patient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Gender_GenderId",
                table: "Patient",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");
        }
    }
}

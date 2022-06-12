using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTriage_Triage_TriageId",
                table: "PatientTriage");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "TriageId",
                table: "PatientTriage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTriage_Triage_TriageId",
                table: "PatientTriage",
                column: "TriageId",
                principalTable: "Triage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientTriage_Triage_TriageId",
                table: "PatientTriage");

            migrationBuilder.AlterColumn<int>(
                name: "TriageId",
                table: "PatientTriage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientTriage_Triage_TriageId",
                table: "PatientTriage",
                column: "TriageId",
                principalTable: "Triage",
                principalColumn: "Id");
        }
    }
}

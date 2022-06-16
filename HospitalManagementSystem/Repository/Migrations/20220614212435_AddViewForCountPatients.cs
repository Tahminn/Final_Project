using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddViewForCountPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW dbo.GetPatientsCount As SELECT Count(Id) CountPatient FROM Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW dbo.GetPatientsCount As SELECT Count(Id) CountPatient FROM Patients");
        }
    }
}

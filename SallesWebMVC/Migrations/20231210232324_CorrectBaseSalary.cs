using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SallesWebMVC.Migrations
{
    public partial class CorrectBaseSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BaseSalary",
                table: "Seller",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseSalary",
                table: "Seller");
        }
    }
}

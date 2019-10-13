using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.EF.SqlServer.Migrations
{
    public partial class CarPropLastService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastService",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastService",
                table: "Cars");
        }
    }
}

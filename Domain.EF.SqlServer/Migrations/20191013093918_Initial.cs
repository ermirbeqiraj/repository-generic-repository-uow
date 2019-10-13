using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.EF.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    VIN = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Odometer = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CarId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CarId",
                table: "Services",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}

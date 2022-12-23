using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RawsonbpoTestProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Identification = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumberOne = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumberTwo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Identification);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}

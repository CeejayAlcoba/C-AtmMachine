using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtmMachine.Migrations
{
    public partial class addEncryptionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "hashed");

            migrationBuilder.AddColumn<byte[]>(
                name: "salted",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salted",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "hashed",
                table: "Users",
                newName: "password");
        }
    }
}

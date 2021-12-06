using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class AddedColumnGithub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "User",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 6, 18, 20, 11, 432, DateTimeKind.Utc).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2021, 12, 6, 18, 3, 39, 346, DateTimeKind.Utc).AddTicks(3122));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 6, 18, 3, 39, 346, DateTimeKind.Utc).AddTicks(3122),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2021, 12, 6, 18, 20, 11, 432, DateTimeKind.Utc).AddTicks(7101));
        }
    }
}

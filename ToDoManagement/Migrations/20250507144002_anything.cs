using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManagement.Migrations
{
    public partial class anything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "todoItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "todoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "todoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "todoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "todoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "todoItems");
        }
    }
}

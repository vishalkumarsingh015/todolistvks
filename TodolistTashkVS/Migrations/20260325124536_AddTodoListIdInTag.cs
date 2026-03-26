using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodolistTashkVS.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoListIdInTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "Tags");
        }
    }
}

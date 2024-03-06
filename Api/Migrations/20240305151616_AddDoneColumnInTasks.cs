using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tasks.Migrations
{
    /// <inheritdoc />
    public partial class AddDoneColumnInTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "done",
                table: "tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "done",
                table: "tasks");
        }
    }
}

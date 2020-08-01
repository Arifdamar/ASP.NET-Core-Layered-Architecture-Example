using Microsoft.EntityFrameworkCore.Migrations;

namespace Arif.ToDo.DataAccess.Migrations
{
    public partial class CreateTableUrgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Urgencies_UrgencyId",
                table: "Tasks",
                column: "UrgencyId",
                principalTable: "Urgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Urgencies_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Urgencies");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Tasks");
        }
    }
}

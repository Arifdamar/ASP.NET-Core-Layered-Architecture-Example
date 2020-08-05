using Microsoft.EntityFrameworkCore.Migrations;

namespace Arif.ToDo.DataAccess.Migrations
{
    public partial class AddColumnPictureInAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Definition",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reports",
                type: "ntext",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}

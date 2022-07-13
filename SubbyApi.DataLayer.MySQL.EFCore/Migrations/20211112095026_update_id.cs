using Microsoft.EntityFrameworkCore.Migrations;

namespace SubbyApi.DataLayer.MySQL.EFCore.Migrations
{
    public partial class update_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SiteSettings",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "SiteSettings",
                newName: "Id");
        }
    }
}

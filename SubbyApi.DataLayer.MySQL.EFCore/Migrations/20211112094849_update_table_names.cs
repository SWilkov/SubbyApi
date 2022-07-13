using Microsoft.EntityFrameworkCore.Migrations;

namespace SubbyApi.DataLayer.MySQL.EFCore.Migrations
{
    public partial class update_table_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UseLogoOnSubscription",
                table: "SiteSettings",
                newName: "use_logo_on_subscription");

            migrationBuilder.RenameColumn(
                name: "UseLogoOnFilter",
                table: "SiteSettings",
                newName: "use_logo_on_filter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "use_logo_on_subscription",
                table: "SiteSettings",
                newName: "UseLogoOnSubscription");

            migrationBuilder.RenameColumn(
                name: "use_logo_on_filter",
                table: "SiteSettings",
                newName: "UseLogoOnFilter");
        }
    }
}

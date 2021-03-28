using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyImageViewerApi.Migrations
{
    public partial class added_imageName_to_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Families",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Families");
        }
    }
}

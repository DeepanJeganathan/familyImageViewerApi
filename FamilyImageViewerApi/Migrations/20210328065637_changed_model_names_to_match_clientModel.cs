using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyImageViewerApi.Migrations
{
    public partial class changed_model_names_to_match_clientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Families",
                newName: "FamilyLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Families",
                newName: "FamilyFirstName");

            migrationBuilder.RenameColumn(
                name: "FamilyRelation",
                table: "Families",
                newName: "Relation");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "Families",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Relation",
                table: "Families",
                newName: "FamilyRelation");

            migrationBuilder.RenameColumn(
                name: "FamilyLastName",
                table: "Families",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FamilyFirstName",
                table: "Families",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Families",
                newName: "BirthDay");
        }
    }
}

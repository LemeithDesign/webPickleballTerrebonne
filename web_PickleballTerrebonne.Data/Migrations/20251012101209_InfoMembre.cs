using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_PickleballTerrebonne.Data.Migrations
{
    /// <inheritdoc />
    public partial class InfoMembre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Membres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Appartement",
                table: "Membres",
                type: "TEXT",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodePostal",
                table: "Membres",
                type: "TEXT",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactUrgence",
                table: "Membres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactUrgenceRelation",
                table: "Membres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactUrgenceTelephone",
                table: "Membres",
                type: "TEXT",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelephoneMobile",
                table: "Membres",
                type: "TEXT",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "Membres",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "Appartement",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "ContactUrgence",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "ContactUrgenceRelation",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "ContactUrgenceTelephone",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "TelephoneMobile",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "Membres");
        }
    }
}

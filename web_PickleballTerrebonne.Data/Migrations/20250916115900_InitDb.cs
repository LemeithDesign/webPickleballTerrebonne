using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_PickleballTerrebonne.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    Courriel = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DateNaissance = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Ville = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PrenomContactUrgence = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NomContactUrgence = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TelephoneContactUrgence = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");
        }
    }
}

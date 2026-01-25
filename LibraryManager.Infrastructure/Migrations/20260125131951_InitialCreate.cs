using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPages = table.Column<int>(type: "int", nullable: false),
                    DateDeSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatutLivre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livres");
        }
    }
}

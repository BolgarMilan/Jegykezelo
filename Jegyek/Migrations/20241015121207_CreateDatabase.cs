using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jegyek.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tantargy",
                columns: table => new
                {
                    Azon = table.Column<Guid>(type: "char(36)", nullable: false),
                    Jegy = table.Column<int>(type: "int", nullable: false),
                    Leiras = table.Column<string>(type: "longtext", nullable: false),
                    ido = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tantargy", x => x.Azon);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tantargy");
        }
    }
}

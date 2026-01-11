using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceAuto.Web.Migrations
{
    /// <inheritdoc />
    public partial class FullSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mecanici",
                columns: table => new
                {
                    MecanicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParolaHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanici", x => x.MecanicId);
                });

            migrationBuilder.CreateTable(
                name: "PieseDeSchimb",
                columns: table => new
                {
                    PiesaDeSchimbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodProdus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Furnizor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieseDeSchimb", x => x.PiesaDeSchimbId);
                });

            migrationBuilder.CreateTable(
                name: "Interventii",
                columns: table => new
                {
                    InterventieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasinaId = table.Column<int>(type: "int", nullable: false),
                    MecanicId = table.Column<int>(type: "int", nullable: false),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DescriereProblema = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ObservatiiMecanic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventii", x => x.InterventieId);
                    table.ForeignKey(
                        name: "FK_Interventii_Masini_MasinaId",
                        column: x => x.MasinaId,
                        principalTable: "Masini",
                        principalColumn: "MasinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interventii_Mecanici_MecanicId",
                        column: x => x.MecanicId,
                        principalTable: "Mecanici",
                        principalColumn: "MecanicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterventiiPiese",
                columns: table => new
                {
                    InterventieId = table.Column<int>(type: "int", nullable: false),
                    PiesaDeSchimbId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    PretUnitarLaDataAplicarii = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterventiiPiese", x => new { x.InterventieId, x.PiesaDeSchimbId });
                    table.ForeignKey(
                        name: "FK_InterventiiPiese_Interventii_InterventieId",
                        column: x => x.InterventieId,
                        principalTable: "Interventii",
                        principalColumn: "InterventieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterventiiPiese_PieseDeSchimb_PiesaDeSchimbId",
                        column: x => x.PiesaDeSchimbId,
                        principalTable: "PieseDeSchimb",
                        principalColumn: "PiesaDeSchimbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interventii_MasinaId",
                table: "Interventii",
                column: "MasinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventii_MecanicId",
                table: "Interventii",
                column: "MecanicId");

            migrationBuilder.CreateIndex(
                name: "IX_InterventiiPiese_PiesaDeSchimbId",
                table: "InterventiiPiese",
                column: "PiesaDeSchimbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterventiiPiese");

            migrationBuilder.DropTable(
                name: "Interventii");

            migrationBuilder.DropTable(
                name: "PieseDeSchimb");

            migrationBuilder.DropTable(
                name: "Mecanici");
        }
    }
}

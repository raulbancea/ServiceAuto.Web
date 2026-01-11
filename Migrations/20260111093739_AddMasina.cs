using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceAuto.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddMasina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masini",
                columns: table => new
                {
                    MasinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumarInmatriculare = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnFabricatie = table.Column<int>(type: "int", nullable: false),
                    SerieSasiu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masini", x => x.MasinaId);
                    table.ForeignKey(
                        name: "FK_Masini_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masini_ClientId",
                table: "Masini",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masini");
        }
    }
}

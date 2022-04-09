using Microsoft.EntityFrameworkCore.Migrations;

namespace Anatomia.Comunes.Migrations
{
    public partial class Insercion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inserciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodInsercion = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NombreInsercion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MusculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inserciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inserciones_Musculos_MusculoId",
                        column: x => x.MusculoId,
                        principalTable: "Musculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inserciones_MusculoId",
                table: "Inserciones",
                column: "MusculoId");

            migrationBuilder.CreateIndex(
                name: "UQ_Insercion_CodInsercion",
                table: "Inserciones",
                column: "CodInsercion",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inserciones");
        }
    }
}

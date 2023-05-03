using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCars.Migrations
{
    /// <inheritdoc />
    public partial class AddAccesoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccesoryCar",
                columns: table => new
                {
                    AccesoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CarsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesoryCar", x => new { x.AccesoriesId, x.CarsId });
                    table.ForeignKey(
                        name: "FK_AccesoryCar_Accesory_AccesoriesId",
                        column: x => x.AccesoriesId,
                        principalTable: "Accesory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccesoryCar_Car_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccesoryCar_CarsId",
                table: "AccesoryCar",
                column: "CarsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccesoryCar");

            migrationBuilder.DropTable(
                name: "Accesory");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicatie_web.Migrations
{
    public partial class PrajituraCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Prajitura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrajituraCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrajituraID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrajituraCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrajituraCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrajituraCategorie_Prajitura_PrajituraID",
                        column: x => x.PrajituraID,
                        principalTable: "Prajitura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prajitura_ClientID",
                table: "Prajitura",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_PrajituraCategorie_CategorieID",
                table: "PrajituraCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_PrajituraCategorie_PrajituraID",
                table: "PrajituraCategorie",
                column: "PrajituraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prajitura_Client_ClientID",
                table: "Prajitura",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prajitura_Client_ClientID",
                table: "Prajitura");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "PrajituraCategorie");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Prajitura_ClientID",
                table: "Prajitura");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Prajitura");
        }
    }
}

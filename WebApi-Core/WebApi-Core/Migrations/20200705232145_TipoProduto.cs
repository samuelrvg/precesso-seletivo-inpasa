using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Core.Migrations
{
    public partial class TipoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoId",
                table: "Produtos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Tipos_TipoId",
                table: "Produtos",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Tipos_TipoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TipoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "TipoProduto",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

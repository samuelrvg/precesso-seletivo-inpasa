using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Core.Migrations
{
    public partial class alteracao_entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Tipos_TipoProdutoTipoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TipoProdutoTipoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TipoProdutoTipoId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "TipoProdutoId",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoProdutos",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProdutos", x => x.TipoProdutoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoProdutos");

            migrationBuilder.DropColumn(
                name: "TipoProdutoId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "TipoProdutoTipoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoProdutoTipoId",
                table: "Produtos",
                column: "TipoProdutoTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Tipos_TipoProdutoTipoId",
                table: "Produtos",
                column: "TipoProdutoTipoId",
                principalTable: "Tipos",
                principalColumn: "TipoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

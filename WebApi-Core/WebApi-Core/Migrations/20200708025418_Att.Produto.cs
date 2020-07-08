using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Core.Migrations
{
    public partial class AttProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Tipos_TipoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TipoId",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}



using Dapper.Contrib.Extensions;

namespace WebApi_Core.Dto.ProdutosDto
{
    [Table("dbo.Produtos")]
    public class EditarProdutoDto
    {
        [Key]
        public int ProdutoId { get; set; }
        public int TipoProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
    }
}

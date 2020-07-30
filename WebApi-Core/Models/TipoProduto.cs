using Dapper.Contrib.Extensions;

namespace WebApi_Core.Models
{
    [Table("dbo.TipoProdutos")]
    public class TipoProduto
    {
        [Key]
        public int TipoProdutoId { get; set; }
        public string TipoNome { get; set; }
    }
}
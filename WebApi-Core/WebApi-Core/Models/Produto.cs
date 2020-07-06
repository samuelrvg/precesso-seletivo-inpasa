using System;

namespace WebApi_Core.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }
        public Tipo TipoProduto { get; set; }
        public DateTime DataCadastro { get; set; }

        public Produto()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
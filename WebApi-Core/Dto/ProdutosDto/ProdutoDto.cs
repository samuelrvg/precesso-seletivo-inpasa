using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Core.Dto.ProdutosDto
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public int TipoProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string DataCadastro { get; set; }
        public string TipoNome { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_Core.Data;

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

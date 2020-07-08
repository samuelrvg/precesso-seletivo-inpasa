using System;
using System.Collections.Generic;
using WebApi_Core.Data;

namespace WebApi_Core.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }               
        public DateTime DataCadastro { get; set; }

        public int TipoId { get; set; }

        private Tipo _tipoProduto;
        public Tipo TipoProduto { 
            get 
            {
                using Context context = new Context();
                _tipoProduto = context.Tipos.Find(TipoId);
                return _tipoProduto;
            } 
            set { _tipoProduto = value; } }

        public Produto()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
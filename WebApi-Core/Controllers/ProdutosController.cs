using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using WebApi_Core.Data;
using WebApi_Core.Models;

namespace WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        
        ConexaoDb conexao = new ConexaoDb();
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        public ProdutosController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
        }        

        [HttpGet]
        public IEnumerable GetProdutos()
        {
            return conexao.Conexao(_configuration)
                .Query("SELECT A.ProdutoId,  " +
                    "A.Nome, A.Descricao," +
                    " A.Preco, A.DataCadastro, " +
                    "B.TipoNome " +
                        "FROM Produtos A INNER JOIN TipoProdutos B ON	A.TipoProdutoId = b.TipoProdutoId");
        }

        [HttpGet("{id}")]
        public IEnumerable Get(int id)
        {
            if (ExisteProduto(id))
            {
                return conexao.Conexao(_configuration)
                .Query("SELECT A.ProdutoId,  " +
                    "A.Nome, A.Descricao," +
                    " A.Preco, A.DataCadastro, " +
                    "B.TipoNome " +
                        $"FROM Produtos A INNER JOIN TipoProdutos B ON	A.TipoProdutoId = b.TipoProdutoId WHERE A.ProdutoId = {id}");
            }
            return "Produto não existe!";
            

        }

        [HttpPost]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            conexao.Conexao(_configuration).Insert(produto);
            return GetProduto(produto.ProdutoId) ;
        }

        private ActionResult<Produto> GetProduto(int produtoId)
        {
            return conexao.Conexao(_configuration).Get<Produto>(produtoId);
        }

        public bool ExisteProduto(int id)
        {
            return _context.Produtos.Any(x => x.ProdutoId == id);
        }
    }
}

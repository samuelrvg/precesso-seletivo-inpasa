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
            if (ExisteTipoProduto(produto.TipoProdutoId))
            {
                if (!ExisteProdutoNome(produto.Nome))
                {
                    produto.DataCadastro = DateTime.Now;
                    conexao.Conexao(_configuration).Insert(produto);
                    return CreatedAtAction("Get", new { id = produto.ProdutoId }, produto);
                }
                return NotFound("Produto já Cadastrado.");
            }
            return NotFound("Tipo Produto não existe.");
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> UpdateProduto(int id, Produto produto)
        {
            if (id == produto.ProdutoId)
            {
                if (ExisteProduto(id))
                {
                    if (ExisteTipoProduto(produto.TipoProdutoId))
                    {
                        var proOriginal = conexao.Conexao(_configuration).Get<Produto>(produto.ProdutoId);
                        produto.DataCadastro = proOriginal.DataCadastro;
                        conexao.Conexao(_configuration).Update<Produto>(produto);
                        return Ok(Get(produto.ProdutoId));
                    }
                    return NotFound("TipoProduto não existe.");
                }
                return NotFound("Produto não existe.");
            }
            return NotFound("Erro! Produto não identificado.");
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> DeleteProduto(int id)
        {
            if (ExisteProduto(id))
            {
                conexao.Conexao(_configuration).Delete(new Produto { ProdutoId = id });
                return Ok("Produto removido com sucesso!");
            }
            return NotFound("Produto não existe.");
        }

        public bool ExisteProduto(int id)
        {
            return _context.Produtos.Any(x => x.ProdutoId == id);
        }

        public bool ExisteTipoProduto(int id)
        {
            return _context.TipoProdutos.Any(x => x.TipoProdutoId == id);
        }

        public bool ExisteProdutoNome(string nome)
        {
            return _context.Produtos.Any(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}

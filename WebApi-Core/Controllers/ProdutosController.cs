using System;
using System.Collections;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi_Core.Data;
using WebApi_Core.Dto.ProdutosDto;
using WebApi_Core.Models;

namespace WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        readonly ConexaoDb conexao = new ConexaoDb();
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        public ProdutosController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable> GetAll()
        {
            var result = conexao.Conexao(_configuration)
                .Query<ListaProdutoDto>("SELECT * FROM Produtos A INNER JOIN TipoProdutos B ON A.TipoProdutoId = b.TipoProdutoId");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ListaProdutoDto> Get(int id)
        {
            if (ExisteProduto(id))
            {
                var result = conexao.Conexao(_configuration)
                .Query<ListaProdutoDto>($"SELECT * FROM Produtos A INNER JOIN TipoProdutos B ON A.TipoProdutoId = b.TipoProdutoId WHERE A.ProdutoId = {id}");
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            if (!ExisteTipoProduto(produto.TipoProdutoId))
            {                
                return NotFound();
            }

            if (!ExisteProdutoNome(produto.Nome))
            {
                produto.DataCadastro = DateTime.Now;
                conexao.Conexao(_configuration).Insert(produto);
                return CreatedAtAction("Get", new { id = produto.ProdutoId }, produto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EditarProdutoDto EditarProdutoDto)
        {
            if (EditarProdutoDto.ProdutoId != id)
            {
                return NotFound();
            }

            if (!ExisteProduto(id))
            {
                return NotFound();
            }

            if (!ExisteTipoProduto(EditarProdutoDto.TipoProdutoId))
            {
                return NotFound();
            }

            conexao.Conexao(_configuration).Update(EditarProdutoDto);
            return Ok();

        }            
        

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            if (ExisteProduto(id))
            {
                conexao.Conexao(_configuration).Delete(new Produto { ProdutoId = id });
                return NoContent();
            }
            return NotFound("Produto não existe.");
        }

        private bool ExisteProduto(int id)
        {
            return _context.Produtos.Any(x => x.ProdutoId == id);
        }

        private bool ExisteTipoProduto(int id)
        {
            return _context.TipoProdutos.Any(x => x.TipoProdutoId == id);
        }

        private bool ExisteProdutoNome(string nome)
        {
            return _context.Produtos.Any(x => x.Nome.ToUpper() == nome.ToUpper());
        }
    }
}

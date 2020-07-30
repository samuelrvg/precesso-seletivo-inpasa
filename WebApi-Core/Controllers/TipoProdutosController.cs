using System.Collections;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi_Core.Data;
using WebApi_Core.Models;

namespace WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutosController : ControllerBase
    {

        ConexaoDb conexao = new ConexaoDb();
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        public TipoProdutosController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable> GetAll()
        {
            var result = conexao.Conexao(_configuration).GetAll<TipoProduto>();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable> Get(int id)
        {
            if (!ExisteTipoProduto(id))
            {
                return NotFound();
            }
            var result = conexao.Conexao(_configuration).Get<TipoProduto>(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<TipoProduto> Create(TipoProduto tipoProduto)
        {
            if (!ExisteTipoProdutoNome(tipoProduto.TipoNome))
            {
                conexao.Conexao(_configuration).Insert(tipoProduto);
                return Ok();
            }
            return NotFound("TipoProduto já Cadastrado.");
         }

        [HttpPut("{id}")]
        public ActionResult<TipoProduto> Update(int id, TipoProduto tipoProduto)
        {
            if (id != tipoProduto.TipoProdutoId)
            {
                return NotFound("Erro! TipoProduto não identificado.");
            }            
            if (!ExisteTipoProduto(id))
            {
                return NotFound("TipoProduto não existe.");
            }            
            if (ExisteTipoProdutoNome(tipoProduto.TipoNome))
            {
                return NotFound("TipoProduto com esse nome já está cadastrado.");
            }            
            conexao.Conexao(_configuration).Update(tipoProduto);
            return NoContent();            
        }

        [HttpDelete("{id}")]
        public ActionResult<TipoProduto> Delete(int id)
        {
            if (TipoEmUso(id))
            {
                return BadRequest();
            }
            if (ExisteTipoProduto(id))
            {
                conexao.Conexao(_configuration).Delete(new TipoProduto { TipoProdutoId = id });
                return Ok("TipoProduto removido com sucesso!");
            }
            return NotFound("TipoProduto não existe.");
        }

        private bool ExisteTipoProduto(int id)
        {
            return _context.TipoProdutos.Any(x => x.TipoProdutoId == id);
        }

        private bool ExisteTipoProdutoNome(string nome)
        {
            return _context.TipoProdutos.Any(x => x.TipoNome.ToUpper() == nome.ToUpper());
        }

        private bool TipoEmUso(int id)
        {
            return _context.Produtos.Any(x => x.TipoProdutoId == id);
        }

    }
}

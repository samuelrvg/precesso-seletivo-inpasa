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
        public IEnumerable GetAll()
        {
            return conexao.Conexao(_configuration)
                    .Query<TipoProduto>($"SELECT *  FROM TipoProdutos");
        }

        [HttpGet("{id}")]
        public IEnumerable Get(int id)
        {
            if (ExisteTipoProduto(id))
            {
                return conexao.Conexao(_configuration)
                    .Query<TipoProduto>($"SELECT *  FROM TipoProdutos WHERE TipoProdutoId = {id}");
            }
            return "TipoProduto não existe!";
        }

        [HttpPost]
        public ActionResult<TipoProduto> Create(TipoProduto tipoProduto)
        {
            if (!ExisteTipoProdutoNome(tipoProduto.TipoNome))
            {
                conexao.Conexao(_configuration).Insert(tipoProduto);
                return CreatedAtAction("Get", new { id = tipoProduto.TipoProdutoId }, tipoProduto);
            }
            return NotFound("TipoProduto já Cadastrado.");
         }

        [HttpPut("{id}")]
        public ActionResult<TipoProduto> Update(int id, TipoProduto tipoProduto)
        {
            if (id == tipoProduto.TipoProdutoId)
            {
                if (ExisteTipoProduto(id))
                {
                    if (!ExisteTipoProdutoNome(tipoProduto.TipoNome))
                    {
                        conexao.Conexao(_configuration).Update(tipoProduto);
                        return Ok(Get(tipoProduto.TipoProdutoId));
                    }
                    return NotFound("TipoProduto com esse nome já está cadastrado.");
                }
                return NotFound("TipoProduto não existe.");
            }
            return NotFound("Erro! TipoProduto não identificado.");
        }

        [HttpDelete("{id}")]
        public ActionResult<TipoProduto> Delete(int id)
        {
            if (ExisteTipoProduto(id))
            {
                conexao.Conexao(_configuration).Delete(new TipoProduto { TipoProdutoId = id });
                return Ok("TipoProduto removido com sucesso!");
            }
            return NotFound("TipoProduto não existe.");
        }


        public bool ExisteTipoProduto(int id)
        {
            return _context.TipoProdutos.Any(x => x.TipoProdutoId == id);
        }

        public bool ExisteTipoProdutoNome(string nome)
        {
            return _context.TipoProdutos.Any(x => x.TipoNome.ToUpper() == nome.ToUpper());
        }



    }
}

using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Core.Data;
using WebApi_Core.Models;

namespace WebApi_Core.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public ProdutoController(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]// GET: api/Produtos
        public IEnumerable<Produto> GetAll()
        {
            using (var con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                IEnumerable<Produto> 
                    result = con.Query<Produto>
                        ("SELECT * FROM Produtos");

                return result;
            }            
        }

        [HttpGet("{id}")] // GET: api/Produtos/5
        public IEnumerable<Produto> Get(int id)
        {
            using (var con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                IEnumerable<Produto>
                    result = con.Query<Produto>
                        ($"SELECT * FROM Produtos WHERE produtoId = '{id}'");

                return result;
            }
        }

        [HttpPut("{id}")] // PUT: api/Produtos/5
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Update(produto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost] // POST: api/Produtos
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);

            if (TipoExists(produto.TipoId))
            {
                produto.TipoProduto = await _context.Tipos.FindAsync(produto.TipoId);
            }
            else
            {
                return NotFound("Tipo de produto não cadastrado.");
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpDelete("{id}")] // DELETE: api/Produtos/5
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }

        private bool TipoExists(int id)
        {
            return _context.Tipos.Any(e => e.TipoId == id);
        }
    }
}
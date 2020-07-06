using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi_Core.Data;
using WebApi_Core.Models;

using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;

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

        // GET: api/Produtos
        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            IEnumerable<Produto> result;
            using (SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                result = con.Query<Produto>("SELECT * FROM Produtos");
            }
            return result;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public IEnumerable<Produto> GetProduto(int id)
        {
            IEnumerable<Produto> result;
            using (SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                result = con.Query<Produto>($"SELECT * FROM Produtos WHERE ProdutoId = '{id}'");
            }
            return result;
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

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

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);

            if (TipoExists(produto.TipoId))
            {
                produto.TipoProduto = _context.Tipos.Find(produto.TipoId);
            } 
            else
            {
                return NotFound("Tipo de produto não cadastrado.");
            }           

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.ProdutoId }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
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

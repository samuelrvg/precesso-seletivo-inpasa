using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi_Core.Data;
using WebApi_Core.Models;

namespace WebApi_Core.Controllers
{
    [Route("api/")]
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


        [HttpGet("produtos")]
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

        [HttpGet("produto/{id}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            // Retorna o produto após a criação;
            return CreatedAtAction(nameof(GetById), 
                new { id = produto.ProdutoId }, produto);
        }


    }
}

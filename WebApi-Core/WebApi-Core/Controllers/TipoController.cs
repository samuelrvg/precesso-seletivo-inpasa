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
    [Route("api/tipos")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public TipoController(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet] // GET ALL
        public IEnumerable<Tipo> GetAll()
        {
            IEnumerable<Tipo> result;
            using (SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                result = con.Query<Tipo>("SELECT * FROM Tipos");
            }
            return result;
        }

        [HttpGet("{id}")] // GET
        public IEnumerable<Tipo> GetProduto(int id)
        {
            IEnumerable<Tipo> result;
            using (SqlConnection con = new SqlConnection(
                _configuration.GetConnectionString("CConnection")))
            {
                result = con.Query<Tipo>($"SELECT * FROM Tipos WHERE TipoId = '{id}'");
            }
            return result;
        }

        
        [HttpPut("{id}")] // PUT
        public async Task<IActionResult> PutTipo(int id, Tipo tipo)
        {
            if (id != tipo.TipoId)
            {
                return BadRequest("Tipo não existe");
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        

        [HttpPost] // POST
        public async Task<ActionResult<Tipo>> PostTipo(Tipo tipo)
        {
            if (TipoNomeExists(tipo.TipoNome))
            {
                return NotFound("Tipo já existente.");
            }
            
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();

            return NotFound("Produto Cadastrado! ");
        }


        [HttpDelete("{id}")] // DELETE
        public async Task<ActionResult<Tipo>> DeleteTipo(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.Tipos.Remove(tipo);
            await _context.SaveChangesAsync();

            return tipo;
        }

        private bool TipoExists(int id)
        {
            return _context.Tipos.Any(e => e.TipoId == id);
        }

        private bool TipoNomeExists(string nome)
        {
            return _context.Tipos.Any(e => e.TipoNome == nome);
        }
    }
}
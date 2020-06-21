using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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


    }
}

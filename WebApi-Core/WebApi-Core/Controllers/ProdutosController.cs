using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApi_Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private readonly IConfiguration _config;
        public ProdutosController(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection ConexaoDb()
        {
            return new SqlConnection(_config.GetConnectionString("Conexaodb"));
        }

        [HttpGet]
        public IEnumerable<Produto> GetProdutos()
        {
            var conexao = ConexaoDb();
            
            return conexao.GetAll<Produto>();
        }

        [HttpPost]
        public ActionResult<Produto> PostProduto(Produto produto)
        {
            return Ok();
        } 

    }
}

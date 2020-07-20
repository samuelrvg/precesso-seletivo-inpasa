using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutosController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public TipoProdutosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



    }
}

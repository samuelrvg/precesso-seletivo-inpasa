using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApi_Core.Data
{
    public class ConexaoDb 
    {
        public SqlConnection Conexao(IConfiguration _config)
        {
            return new SqlConnection(_config.GetConnectionString("Conexaodb"));
        }
    }
}

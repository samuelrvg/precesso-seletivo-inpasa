using Microsoft.EntityFrameworkCore;
using WebApi_Core.Models;

namespace WebApi_Core.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}
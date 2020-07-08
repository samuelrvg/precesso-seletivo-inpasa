using Microsoft.EntityFrameworkCore;
using WebApi_Core.Models;

namespace WebApi_Core.Data
{
    public class Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ProdDB;Trusted_Connection=true;"
                );
        }
    }
}
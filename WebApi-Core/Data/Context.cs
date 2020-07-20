using Microsoft.EntityFrameworkCore;
using WebApi_Core.Models;

namespace WebApi_Core.Data
{
    public class Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=Banco;Trusted_Connection=true;"
                );
        }
    }
}
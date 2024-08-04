using API_Two.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Two.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Investimento> Investimentos { get; set; }
    }
}

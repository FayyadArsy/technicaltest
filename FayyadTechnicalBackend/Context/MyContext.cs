using FayyadTechnicalBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FayyadTechnicalBackend.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Items> Items { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

    }
}

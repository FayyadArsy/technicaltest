using FayyadTechnicalBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FayyadTechnicalBackend.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Items> Items { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}

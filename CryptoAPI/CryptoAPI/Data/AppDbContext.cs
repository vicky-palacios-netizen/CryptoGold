using CryptoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }

        public DbSet<Movimiento> Movimientos { get; set; }

    }
}

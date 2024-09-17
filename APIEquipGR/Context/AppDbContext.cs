using APIEquipGR.Models;
using Microsoft.EntityFrameworkCore;

namespace APIEquipGR.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Lote> Lote { get; set; }
    }
}

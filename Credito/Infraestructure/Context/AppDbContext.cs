using Domain.Core.Entities;
using Infraestructure.Map;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FinanciamentoMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<FinanciamentoEntity> Financiamentos { get; set; }
        public DbSet<ParcelaEntity> Parcelas { get; set; }
    }
}

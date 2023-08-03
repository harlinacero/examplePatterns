using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaIngresoBibliotecario.Api.Domain.Entities;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infrastructure
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration Config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            modelBuilder.Entity<Prestamo>(f => f.HasKey(e => e.Id));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Prestamo> Prestamos { get; set; }
    }
}

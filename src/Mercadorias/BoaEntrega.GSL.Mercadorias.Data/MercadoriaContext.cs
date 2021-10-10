using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Core.DomainObjects;
using BoaEntrega.GSL.Mercadorias.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Mercadorias.Data
{
    public class MercadoriaContext : DbContext, IUnitOfWork
    {
        public MercadoriaContext(DbContextOptions<MercadoriaContext> options)
            : base(options) { }

        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<Deposito> Depositos { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deposito>()
                .OwnsOne<Endereco>(c => c.Endereco);
            modelBuilder.Entity<Deposito>()
                .Property(d => d.Codigo).ValueGeneratedOnAdd();
            modelBuilder.Entity<Mercadoria>()
            .OwnsOne<Endereco>(c => c.EnderecoEntrega);


        }
    }
}

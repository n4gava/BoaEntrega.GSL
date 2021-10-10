using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Cadastros.Data
{
    public class CadastrosContext : DbContext, IUnitOfWork
    {
        public CadastrosContext(DbContextOptions<CadastrosContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .OwnsOne<Endereco>(c => c.Endereco);
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Codigo).ValueGeneratedOnAdd();

            modelBuilder.Entity<Fornecedor>()
                .OwnsOne<Endereco>(c => c.Endereco);
            modelBuilder.Entity<Fornecedor>()
                .Property(c => c.Codigo).ValueGeneratedOnAdd();
        }
    }
}

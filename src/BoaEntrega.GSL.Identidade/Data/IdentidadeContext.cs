using BoaEntrega.GSL.Core.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BoaEntrega.GSL.Identidade.Data
{
    public class IdentidadeContext : IdentityDbContext, IUnitOfWork
    {
        public IdentidadeContext(DbContextOptions<IdentidadeContext> options) : base(options)
        {

        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}

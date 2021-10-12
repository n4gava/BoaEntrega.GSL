using System.Threading.Tasks;

namespace BoaEntrega.GSL.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

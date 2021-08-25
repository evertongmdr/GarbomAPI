using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces.Objects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task EnviarEmail(List<string> recebedores, string sujeito, string mensagem);
    }
}

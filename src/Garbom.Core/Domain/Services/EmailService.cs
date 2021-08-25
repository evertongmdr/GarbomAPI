using Garbom.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Services
{
    public class EmailService : IEmailService
    {
        public async Task EnviarEmail(List<string> recebedores, string sujeito, string mensagem)
        {

            await Task.Delay(2000);
            Console.Write("E-mail fake enviado com sucesso!");
        }
    }
}

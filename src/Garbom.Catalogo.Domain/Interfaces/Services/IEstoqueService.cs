﻿using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Interfaces.Services
{
    public interface IEstoqueService : IDisposable
    {
        Task<ValidationResult> DebitarEstoque(Guid produtoId, int quantidade);
        Task<ValidationResult> ReporEstoque(Guid produtoId, int quantidade);

    }
}
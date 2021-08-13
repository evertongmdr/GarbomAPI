using AutoMapper;
using FluentValidation.Results;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Objects;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.AppServices
{
    public class ProdutoAppService : Service, IProdutoAppService
    {
        private readonly IReadOnlyProdutoRepository _readOnlyProdutoRepository;
        private readonly IWriteOnlyProdutoRepository _writeOnlyProdutoRepository;
        private readonly IMapper _mapper;

        public ProdutoAppService(
            IReadOnlyProdutoRepository readOnlyProdutoRepository,
            IWriteOnlyProdutoRepository writeOnlyProdutoRepository,
            IMapper mapper
            )
        {
            _readOnlyProdutoRepository = readOnlyProdutoRepository;
            _writeOnlyProdutoRepository = writeOnlyProdutoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _readOnlyProdutoRepository.ObterPorId(id));
        }

        public async Task<ValidationResult> Adicionar(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _writeOnlyProdutoRepository.Adicionar(produto);

           return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _readOnlyProdutoRepository?.Dispose();
            _writeOnlyProdutoRepository?.Dispose();
        }
    }
}

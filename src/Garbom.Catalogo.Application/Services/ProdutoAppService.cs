using AutoMapper;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories.Reads;
using Garbom.Catalogo.Domain.Interfaces.Repositories.Writes;
using Garbom.Catalogo.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
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

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _readOnlyProdutoRepository.ObterPorId(id);
        }

        public async Task Adicionar(ProdutoDTO produtoDTO)
        {

            var produto = _mapper.Map<Produto>(produtoDTO);
            _writeOnlyProdutoRepository.Adicionar(produto);

            await _writeOnlyProdutoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _readOnlyProdutoRepository?.Dispose();
            _writeOnlyProdutoRepository?.Dispose();
        }
    }
}

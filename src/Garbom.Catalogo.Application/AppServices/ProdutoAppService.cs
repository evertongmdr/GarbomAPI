using AutoMapper;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Application;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.AppServices
{
    public class ProdutoAppService : AppService, IProdutoAppService
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

        public async Task<ProdutoDTO> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _readOnlyProdutoRepository.ObterPorId(id));
        }

        public async Task<AppValidationResult<ProdutoDTO>> AdicionarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            if (!produto.EhValido())
                return new AppValidationResult<ProdutoDTO>(produto.ValidationResult);

            var codigoJaExiste = await _readOnlyProdutoRepository.ExisteAlgum(p => p.Codigo == produto.Codigo);

            if (codigoJaExiste)
            {
                AdicionarErro("Produto", "Código do produto já cadastrado", HttpStatusCode.BadRequest);
                return new AppValidationResult<ProdutoDTO>(ValidationResult);
            }
                


            _writeOnlyProdutoRepository.Adicionar(produto);

            produtoDTO.Id = produto.Id;
         
            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork, produtoDTO);
        }

        public async Task<CategoriaDTO> ObterCategoriaPorId(Guid id)
        {
            return _mapper.Map<CategoriaDTO>(await _readOnlyProdutoRepository.ObterCategoriaPorId(id));
        }

        public async Task<AppValidationResult<CategoriaDTO>> AdicionarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            if (!categoria.EhValido())
                return new AppValidationResult<CategoriaDTO>(categoria.ValidationResult);

            _writeOnlyProdutoRepository.AdicionarCategoria(categoria);
            categoriaDTO.Id = categoria.Id;

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork, categoriaDTO);
        }

        public void Dispose()
        {
            _readOnlyProdutoRepository?.Dispose();
            _writeOnlyProdutoRepository?.Dispose();
        }
    }
}

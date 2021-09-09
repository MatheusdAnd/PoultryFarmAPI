using System;
using System.Threading.Tasks;
using AutoMapper;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;
using PoultryDomain;
using PoultryPersistence.Contratos;

namespace PoultryApplication
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IProdutoPersist _produtoPersist;
        private readonly IMapper _mapper;
        public ProdutoService(IGeralPersist geralPersist,
                              IProdutoPersist produtoPersist,
                              IMapper mapper)
        {
            _geralPersist = geralPersist;
            _produtoPersist = produtoPersist;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> AddProduto(ProdutoDTO model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _geralPersist.Add<Produto>(produto);
                
                if (await _geralPersist.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDTO>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> UpdateProduto(int produtoId, ProdutoDTO model)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) return null;

                model.Id = produto.Id;
                _mapper.Map(model, produto);
                _geralPersist.Update<Produto>(produto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var produtoRetorno = await _produtoPersist.GetProdutoByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDTO>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) throw new Exception("Produto para delete não encontrado.");

                _geralPersist.Delete<Produto>(produto);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDTO[]> GetAllProdutosAsync()
        {
            try
            {
                var produtos = await _produtoPersist.GetAllProdutosAsync();
                if (produtos == null) return null;

                var resultado = _mapper.Map<ProdutoDTO[]>(produtos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO[]> GetAllProdutosByNomeAsync(string nome)
        {
            try
            {
                var produtos = await _produtoPersist.GetAllProdutosByNomeAsync(nome);
                if (produtos == null) return null;

                var resultado = _mapper.Map<ProdutoDTO[]>(produtos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produto = await _produtoPersist.GetProdutoByIdAsync(produtoId);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDTO>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
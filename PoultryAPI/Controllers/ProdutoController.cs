using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;

namespace PoultryAPI.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task <IActionResult> Post(ProdutoDTO model)
        {
            try
            {
                var produto = await _produtoService.AddProduto(model);
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar produto. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, ProdutoDTO model)
        {
            try
            {
                var produto = await _produtoService.UpdateProduto(id, model);
                if (produto == null) return NoContent();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar produto. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _produtoService.DeleteProduto(id) ?
                Ok("Deletado.") :
                BadRequest("Produto não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar produto. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync();
                if (produtos == null) return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produtos = await _produtoService.GetProdutoByIdAsync(id);
                if (produtos == null) return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar produto. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosByNomeAsync(nome);
                if (produtos == null) return NoContent();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }            
    }
}
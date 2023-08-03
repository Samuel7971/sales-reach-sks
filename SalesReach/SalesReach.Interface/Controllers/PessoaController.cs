using Microsoft.AspNetCore.Mvc;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Interface.Attributes;
using SalesReach.Interface.Controllers.Shared;

namespace SalesReach.Interface.Controllers
{
    [Route("v1/pessoa")]
    [ApiController]
    public class PessoaController : APIControllers
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodasAsync()
        {
            var retorno = await _pessoaService.BuscarTodosAsync();
            return retorno.Any() ? ResponseOk(retorno) : ResponseNotFound("Erro ao buscar lista de Pessoas."); 
        }

        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var retorno = await _pessoaService.BuscarPorIdAsync(id);
            return retorno is not null ? ResponseOk(retorno) : ResponseNotFound("Id não localizada.");
        }

        [HttpGet("{nome}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorNomeAsync(string nome)
        {
            var retorno = await _pessoaService.BuscarPorNomeAsync(nome);
            return retorno is not null ? ResponseOk(retorno) : ResponseNotFound("Nome não localizado.");
        }

        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(PessoaModel pessoa)
        {
            if (!ModelState.IsValid) return ResponseBadRequest();

            var response = await _pessoaService.InserirAsync(pessoa);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Pessoa.");
        }

        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(PessoaModel pessoa)
        {
            if(ModelState.IsValid) return ResponseBadRequest();

            var response = await _pessoaService.AtualizarAsync(pessoa);
            return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar pessoa.");
        }

        [HttpHead("{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerificarSeExisteAsync(int id)
        {
            var retorno = await _pessoaService.VerificarSeExisteAsync(id);
            return retorno ? ResponseNoContent() : ResponseNotFound();
        }

        [HttpPatch("{id}/{ativo}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAtivoAsync(int id, bool ativo)
        {
            var response = await _pessoaService.AtualizarAtivoAsync(id, ativo);
            return response > 0 ? ResponseNoContent() : ResponseNotFound("Não encontrado.");
        }


    }
}

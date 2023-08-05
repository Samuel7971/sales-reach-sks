using FluentValidation;
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
        private readonly IValidator<PessoaModel> _pessoaValidator;
        public PessoaController(IPessoaService pessoaService, IValidator<PessoaModel> pessoaValidator)
        {
            _pessoaService = pessoaService;
            _pessoaValidator = pessoaValidator;
        }

        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodasAsync()
        {
            var response = await _pessoaService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response) : ResponseNotFound("Erro ao buscar lista de Pessoas."); 
        }

        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var response = await _pessoaService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Pessoa não localizada.");
        }

        [HttpGet("{nome}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorNomeAsync(string nome)
        {
            var response = await _pessoaService.BuscarPorNomeAsync(nome);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Nome não localizado.");
        }

        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(PessoaModel pessoaModel)
        {
            var modelValidator = _pessoaValidator.Validate(pessoaModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaService.InserirAsync(pessoaModel);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Pessoa.");
        }

        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(PessoaModel pessoaModel)
        {
            var modelValidator = _pessoaValidator.Validate(pessoaModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaService.AtualizarAsync(pessoaModel);
            return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar pessoa.");
        }

        [HttpHead("{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerificarSeExisteAsync(int id)
        {
            var response = await _pessoaService.VerificarSeExisteAsync(id);
            return response ? ResponseNoContent() : ResponseNotFound();
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

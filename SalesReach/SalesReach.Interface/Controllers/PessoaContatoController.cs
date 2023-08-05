using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SalesReach.Application.Models;
using SalesReach.Application.Services;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Interface.Attributes;
using SalesReach.Interface.Controllers.Shared;

namespace SalesReach.Interface.Controllers
{
    [Route("v1/contato")]
    [ApiController]
    public class PessoaContatoController : APIControllers
    {
        private readonly IPessoaContatoService _pessoaContatoService;
        private readonly IValidator<PessoaContatoModel> _pessoaContatoValidator;
        public PessoaContatoController(IPessoaContatoService pessoaContatoService, IValidator<PessoaContatoModel> pessoaContatoValidator)
        {
            _pessoaContatoService = pessoaContatoService;
            _pessoaContatoValidator = pessoaContatoValidator;
        }

        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodasAsync()
        {
            var response = await _pessoaContatoService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response) : ResponseNotFound("Erro ao buscar lista de Contatos");
        }

        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            if (id <= 0) return ResponseBadRequest();

            var response = await _pessoaContatoService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Contato não localizada.");
        }

        [HttpGet("{numero}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorNumeroAsync(string numero)
        {
            if (string.IsNullOrEmpty(numero)) return ResponseBadRequest();

            var response = await _pessoaContatoService.BuscarPorNumeroAsync(numero);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Contato não localizada.");
        }

        [HttpGet("email/{email}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) return ResponseBadRequest();

            var response = await _pessoaContatoService.BuscarPorEmailAsync(email);
            return response is not null ? ResponseOk(response) : ResponseNotFound("E-mail não localizado.");
        }

        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(PessoaContatoModel contatoModel)
        {
            var modelValidator = _pessoaContatoValidator.Validate(contatoModel);

            if (!modelValidator.IsValid) 
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaContatoService.InserirAsync(contatoModel);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Contatos.");
        }

        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(PessoaContatoModel contatoModel)
        {
            var modelValidator = _pessoaContatoValidator.Validate(contatoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaContatoService.AtualizarAsync(contatoModel);
            return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar Contatos.");
        }
    }
}

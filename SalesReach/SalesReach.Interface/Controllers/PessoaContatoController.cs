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
        private readonly IValidator<ContatoModel> _pessoaContatoValidator;
        public PessoaContatoController(IPessoaContatoService pessoaContatoService, IValidator<ContatoModel> pessoaContatoValidator)
        {
            _pessoaContatoService = pessoaContatoService;
            _pessoaContatoValidator = pessoaContatoValidator;
        }

        /// <summary>
        /// Buscar todos
        /// </summary>
        /// <returns>Lista de contatos</returns>
        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodasAsync()
        {
            var response = await _pessoaContatoService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response) : ResponseNotFound("Erro ao buscar lista de Contatos");
        }

        /// <summary>
        /// Buscar contato por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Contato localizado por Id</returns>
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

        /// <summary>
        /// Buscar contato por Número telefone
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Contato localizado por número telefone</returns>
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

        /// <summary>
        /// Buscar contato por e-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Contato localizado por e-mail</returns>
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

        /// <summary>
        /// Inseri novo contato
        /// </summary>
        /// <param name="contatoModel"></param>
        /// <returns>Status code 201</returns>
        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(ContatoModel contatoModel)
        {
            var modelValidator = _pessoaContatoValidator.Validate(contatoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaContatoService.InserirAsync(contatoModel);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Contatos.");
        }

        /// <summary>
        /// Atualiza Contato
        /// </summary>
        /// <param name="contatoModel"></param>
        /// <returns>Status code</returns>
        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(ContatoModel contatoModel)
        {
            var modelValidator = _pessoaContatoValidator.Validate(contatoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaContatoService.AtualizarAsync(contatoModel);
            return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar Contatos.");
        }
    }
}

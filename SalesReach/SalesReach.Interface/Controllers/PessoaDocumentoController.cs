using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Interface.Attributes;
using SalesReach.Interface.Controllers.Shared;

namespace SalesReach.Interface.Controllers
{
    [Route("v1/documento")]
    [ApiController]
    public class PessoaDocumentoController : APIControllers
    {
        private readonly IPessoaDocumentoService _documentoService;
        private readonly IValidator<PessoaDocumentoModel> _pessoaDocumentoValidator;
        public PessoaDocumentoController(IPessoaDocumentoService documentoService, IValidator<PessoaDocumentoModel> pessoaDocumentoValidator)
        {
            _documentoService = documentoService;
            _pessoaDocumentoValidator = pessoaDocumentoValidator;
        }

        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var response = await _documentoService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Documento não encontrado.");
        }

        [HttpGet("{numero}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorId(string numero)
        {
            var response = await _documentoService.BuscarPorNumeroAsync(numero);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Documento não encontrado.");
        }

        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(PessoaDocumentoModel documentoModel)
        {
            var modelValidator = _pessoaDocumentoValidator.Validate(documentoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _documentoService.AtualizarAsync(documentoModel);
            return response > 0 ? ResponseNoContent() : ResponseNotFound("Erro ao atualizar Documento.");
        }

        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(PessoaDocumentoModel documentoModel)
        {
            var modelValidator = _pessoaDocumentoValidator.Validate(documentoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _documentoService.InserirAsync(documentoModel);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Documento.");
        }

        [HttpHead("{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status204NoContent)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerificarSeExisteAsync(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = await _documentoService.VerificarSeExisteAsync(id);
            return response ? ResponseOk() : ResponseNotFound();
        }
    }
}

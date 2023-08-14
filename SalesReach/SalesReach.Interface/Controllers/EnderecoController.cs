using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SalesReach.Application.Models;
using SalesReach.Application.Services;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Application.Validations;
using SalesReach.Domain.Entities;
using SalesReach.Interface.Attributes;
using SalesReach.Interface.Controllers.Shared;

namespace SalesReach.Interface.Controllers
{
    [Route("v1/endereco")]
    [ApiController]
    public class EnderecoController : APIControllers
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IValidator<EnderecoModel> _enderecoValidator;
        public EnderecoController(IEnderecoService enderecoService, IValidator<EnderecoModel> enderecoValidator)
        {
            _enderecoService = enderecoService;
            _enderecoValidator = enderecoValidator;
        }

        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodosAsync()
        {
            var response = await _enderecoService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response): ResponseNotFound();
        }

        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var response = await _enderecoService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Endereço não localizado.");
        }

        [HttpGet("cep/{cep}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorCEPAsync(string cep)
        {
            var response = await _enderecoService.BuscarPorCEPAsync(cep);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Endereço não localizado.");
        }

        [HttpGet("logradouro/{logradouro}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorLogradouroAsync(string logradouro)
        {
            var response = await _enderecoService.BuscarPorLogradouroAsync(logradouro);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Endereço não localizado.");
        }

        [HttpPut()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAsync(EnderecoModel enderecoModel)
        {
            var modelValidator = _enderecoValidator.Validate(enderecoModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _enderecoService.AtualizarAsync(enderecoModel);    
            return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar Endereço.");
        }

        //[HttpPost()]
        //[CustomResponse(StatusCodes.Status200OK)]
        //[CustomResponse(StatusCodes.Status400BadRequest)]
        //[CustomResponse(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> InserirAsync(EnderecoModel enderecoModel)
        //{
        //    var modelValidator = _enderecoValidator.Validate(enderecoModel);

        //    if (!modelValidator.IsValid)
        //        return BadRequest(modelValidator.Errors);

        //    var response = await _enderecoService.InserirAsync(enderecoModel);
        //    return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir novo Endereço.");
        //}

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching;
using SalesReach.Application.Models;
using SalesReach.Application.Services.Interfaces;
using SalesReach.Interface.Attributes;
using SalesReach.Interface.Controllers.Shared;

namespace SalesReach.Interface.Controllers
{
    [Route("v1/cliente")]
    [ApiController]
    public class ClienteController : APIControllers
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Buscar todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodosAsync()
        {
            var response = await _clienteService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response) : ResponseNotFound("Erro ao consultar clientes.");
        }

        /// <summary>
        /// Buscar cliente por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var response = await _clienteService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Cliente não localizado.");
        }

        /// <summary>
        /// Ativar ou Inativar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [HttpPatch("{id}/{ativo}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarAtivoAsync(int id, bool ativo)
        {
            var response = await _clienteService.AtualizarAtivoAsync(id, ativo);
            return response > 0 ? ResponseNoContent() : ResponseNotFound("Erro ao atualizar Cliente.");
        }

        /// <summary>
        /// Inserir novo Cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns></returns>
        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(ClienteModel clienteModel)
        {
            var response = await _clienteService.InserirAsync(clienteModel);
            return response > 0 ? ResponseCreated() : ResponseBadRequest("Erro ao inserir cliente.");
        }
    }
}

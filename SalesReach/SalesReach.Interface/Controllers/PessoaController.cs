using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SalesReach.Application.Models.RequestModels;
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
        private readonly IValidator<PessoaRequestModel> _pessoaValidator;
        public PessoaController(IPessoaService pessoaService, IValidator<PessoaRequestModel> pessoaValidator)
        {
            _pessoaService = pessoaService;
            _pessoaValidator = pessoaValidator;
        }

        /// <summary>
        /// Buscar todo registro de Pessoa
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarTodasAsync()
        {
            var response = await _pessoaService.BuscarTodosAsync();
            return response.Any() ? ResponseOk(response) : ResponseNotFound("Erro ao buscar lista de Pessoas."); 
        }

        /// <summary>
        /// Buscar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var response = await _pessoaService.BuscarPorIdAsync(id);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Pessoa não localizada.");
        }

        /// <summary>
        /// Buscar Por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("{nome}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPorNomeAsync(string nome)
        {
            var response = await _pessoaService.BuscarPorNomeAsync(nome);
            return response is not null ? ResponseOk(response) : ResponseNotFound("Nome não localizado.");
        }

        /// <summary>
        /// Inserir nova Pessoa
        /// </summary>
        /// <param name="pessoaModel"></param>
        /// <returns></returns>
        [HttpPost()]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InserirAsync(PessoaRequestModel pessoaModel)
        {
            var modelValidator = _pessoaValidator.Validate(pessoaModel);

            if (!modelValidator.IsValid)
                return BadRequest(modelValidator.Errors);

            var response = await _pessoaService.InserirAsync(pessoaModel);
            return response is not null ? ResponseCreated(response) : ResponseBadRequest("Erro ao inserir novo Pessoa.");
        }

        ///// <summary>
        ///// Atualizar Pessoa
        ///// </summary>
        ///// <param name="pessoaModel"></param>
        ///// <returns></returns>
        //[HttpPut()]
        //[CustomResponse(StatusCodes.Status200OK)]
        //[CustomResponse(StatusCodes.Status400BadRequest)]
        //[CustomResponse(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> AtualizarAsync(PessoaModel pessoaModel)
        //{
        //    var modelValidator = _pessoaValidator.Validate(pessoaModel);

        //    if (!modelValidator.IsValid)
        //        return BadRequest(modelValidator.Errors);

        //    var response = await _pessoaService.AtualizarAsync(pessoaModel);
        //    return response > 0 ? ResponseNoContent() : ResponseBadRequest("Erro ao atualizar pessoa.");
        //}

        /// <summary>
        /// Verificar se existe Pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpHead("{id}")]
        [CustomResponse(StatusCodes.Status200OK)]
        [CustomResponse(StatusCodes.Status400BadRequest)]
        [CustomResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerificarSeExisteAsync(int id)
        {
            var response = await _pessoaService.VerificarSeExisteAsync(id);
            return response ? ResponseNoContent() : ResponseNotFound();
        }

        /// <summary>
        /// Ativar ou Inativar Pessoa
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
            var response = await _pessoaService.AtualizarAtivoAsync(id, ativo);
            return response > 0 ? ResponseNoContent() : ResponseNotFound("Não encontrado.");
        }


    }
}

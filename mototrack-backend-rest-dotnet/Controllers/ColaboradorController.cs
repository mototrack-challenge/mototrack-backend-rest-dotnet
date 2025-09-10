using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Hosting;
using mototrack_backend_rest_dotnet.Doc.Samples;
using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Services;
using mototrack_backend_rest_dotnet.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace mototrack_backend_rest_dotnet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _colaboradorService;

    public ColaboradorController(IColaboradorService colaboradorService) 
    {
        _colaboradorService = colaboradorService;
    }

    [HttpGet]
    [SwaggerOperation(
            Summary = "Lista de colaboradores",
            Description = "Retorna a lista completa de colaboradores cadastrados."
        )]
    [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<ColaboradorEntity>))]
    [SwaggerResponse(statusCode: 204, description: "Lista não tem dados")]
    [SwaggerResponseExample(statusCode: 200, typeof(ColaboradorResponseListSample))]
    [EnableRateLimiting("MotoTrack")]
    public async Task<IActionResult> Get(int deslocamento = 0, int registrosRetornados = 10)
    {
        var result = await _colaboradorService.ObterTodosColaboradoresAsync(deslocamento, registrosRetornados);

        if (!result.Data.Any())
            return NoContent();

        var hateaos = new
        {
            data = result.Data.Select(c => new {
                c.Id,
                c.Nome,
                c.Matricula,
                c.Email,
                c.Servicos,
                links = new
                {
                    self = Url.Action(nameof(GetId), "Colaborador", new { id = c.Id }, Request.Scheme),
                    put = Url.Action(nameof(Put), "Colaborador", new { id = c.Id }, Request.Scheme),
                    delete = Url.Action(nameof(Delete), "Colaborador", new { id = c.Id }, Request.Scheme)
                }
            }),
            links = new
            {
                self = Url.Action(nameof(GetId), "Colaborador", null),
                post = Url.Action(nameof(Post), "Colaborador", null, Request.Scheme),
            },
            pagina = new
            {
                result.Deslocamento,
                result.RegistrosRetornados,
                result.TotalRegistros
            }
        };

        return Ok(hateaos);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
            Summary = "Obtém um colaborador pelo ID",
            Description = "Retorna o colaborador correspondente ao ID informado."
        )]
    [SwaggerResponse(statusCode: 200, description: "Colaborador encontrado", type: typeof(ColaboradorEntity))]
    [SwaggerResponse(statusCode: 404, description: "Colaborador não encontrado")]
    [SwaggerResponseExample(statusCode: 200, typeof(ColaboradorResponseSample))]
    public async Task<IActionResult> GetId(long id)
    {
        var colaborador = await _colaboradorService.ObterColaboradorPorIdAsync(id);

        if (colaborador is null)
            return NotFound();

        return Ok(colaborador);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Cadastra um novo colaborador",
        Description = "Cadastra um novo colaborador no sistema e retorna os dados cadastrados."
    )]
    [SwaggerRequestExample(typeof(ColaboradorDTO), typeof(ColaboradorRequestSample))]
    [SwaggerResponse(statusCode: 200, description: "Colaborador salvo com sucesso", type: typeof(ColaboradorEntity))]
    [SwaggerResponseExample(statusCode: 200, typeof(ColaboradorResponseSample))]
    public async Task<IActionResult> Post(ColaboradorDTO dto)
    {
        try
        {
            var colaboradorCadastrado = await _colaboradorService.AdicionarColaboradorAsync(dto);
            return Ok(colaboradorCadastrado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza um colaborador",
        Description = "Edita os dados de um colaborador já cadastrado com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Colaborador atualizado com sucesso", type: typeof(ColaboradorEntity))]
    [SwaggerResponse(statusCode: 400, description: "Erro na requisição (validação ou dados inválidos)")]
    [SwaggerResponse(statusCode: 404, description: "Colaborador não encontrado")]
    [SwaggerRequestExample(typeof(ColaboradorDTO), typeof(ColaboradorRequestSample))]
    [SwaggerResponseExample(statusCode: 200, typeof(ColaboradorResponseSample))]
    public async Task<IActionResult> Put(long id, ColaboradorDTO dto)
    {
        try
        {
            var colaboradorEditado = await _colaboradorService.EditarColaboradorAsync(id, dto);
            if (colaboradorEditado is null)
                return NotFound();

            return Ok(colaboradorEditado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Remove um colaborador",
        Description = "Exclui permanentemente um colaborador com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Colaborador removido com sucesso")]
    [SwaggerResponse(statusCode: 404, description: "Colaborador não encontrado")]
    public async Task<IActionResult> Delete(long id)
    {
        var colaborador = await _colaboradorService.DeletarColaboradorAsync(id);

        if (colaborador is null)
            return NotFound();

        return Ok(colaborador);
    }
}

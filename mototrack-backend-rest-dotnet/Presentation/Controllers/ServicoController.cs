using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Doc.Samples;
using mototrack_backend_rest_dotnet.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Security.Cryptography;

namespace mototrack_backend_rest_dotnet.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : ControllerBase
{
    private readonly IServicoService _servicoService;

    public ServicoController(IServicoService servicoService)
    {
        _servicoService = servicoService;
    }

    [HttpGet]
    [SwaggerOperation(
            Summary = "Lista de serviços",
            Description = "Retorna a lista completa de serviços cadastrados."
        )]
    [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<ServicoEntity>))]
    [SwaggerResponse(statusCode: 204, description: "Lista não tem dados")]
    [SwaggerResponseExample(statusCode: 200, typeof(ServicoResponseListSample))]
    [EnableRateLimiting("MotoTrack")]
    public async Task<IActionResult> Get(int deslocamento = 0, int registrosRetornados = 10)
    {
        var result = await _servicoService.ObterTodosServicosAsync(deslocamento, registrosRetornados);
        if (!result.Data.Any())
            return NoContent();

        var hateaos = new
        {
            data = result.Data.Select(s => new {
                s.Id,
                s.Descricao,
                s.DataCadastro,
                s.Status,
                s.MotoId,
                Colaborador = s.Colaborador != null ? new
                {
                    s.Colaborador.Id,
                    s.Colaborador.Nome,
                    s.Colaborador.Matricula,
                    s.Colaborador.Email
                } : null,
                links = new
                {
                    self = Url.Action(nameof(GetId), "Servico", new { id = s.Id }, Request.Scheme),
                    put = Url.Action(nameof(Put), "Servico", new { id = s.Id }, Request.Scheme),
                    delete = Url.Action(nameof(Delete), "Servico", new { id = s.Id }, Request.Scheme)
                }
            }),
            links = new
            {
                self = Url.Action(nameof(GetId), "Servico", null),
                post = Url.Action(nameof(Post), "Servico", null, Request.Scheme),
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
            Summary = "Obtém um serviço pelo ID",
            Description = "Retorna o serviço correspondente ao ID informado."
        )]
    [SwaggerResponse(statusCode: 200, description: "Serviço encontrado", type: typeof(ServicoEntity))]
    [SwaggerResponse(statusCode: 404, description: "Serviço não encontrado")]
    [SwaggerResponseExample(statusCode: 200, typeof(ServicoResponseSample))]
    public async Task<IActionResult> GetId(long id)
    {
        var servico = await _servicoService.ObterServicoPorIdAsync(id);

        if (servico is null)
            return NotFound();

        var response = new
        {
            servico.Id,
            servico.Descricao,
            servico.DataCadastro,
            servico.Status,
            servico.MotoId,
            Colaborador = servico.Colaborador != null ? new
            {
                servico.Colaborador.Id,
                servico.Colaborador.Nome,
                servico.Colaborador.Matricula,
                servico.Colaborador.Email
            } : null,
            links = new
            {
                self = Url.Action(nameof(GetId), "Servico", new { id = servico.Id }, Request.Scheme),
                put = Url.Action(nameof(Put), "Servico", new { id = servico.Id }, Request.Scheme),
                delete = Url.Action(nameof(Delete), "Servico", new { id = servico.Id }, Request.Scheme)
            }
        };

        return Ok(response);
    }

    [HttpGet("moto/{motoId}")]
    [SwaggerOperation(
    Summary = "Lista serviços de uma moto",
    Description = "Retorna todos os serviços vinculados a uma moto específica pelo ID."
)]
    [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<ServicoEntity>))]
    [SwaggerResponse(statusCode: 404, description: "Moto não encontrada ou sem serviços")]
    [SwaggerResponseExample(statusCode: 200, typeof(ServicoResponseListSample))]
    public async Task<IActionResult> GetByMotoId(long motoId)
    {
        var servicos = await _servicoService.ObterServicosPorMotoIdAsync(motoId);

        if (servicos == null || !servicos.Any())
            return Ok(new List<ServicoEntity>());

        return Ok(servicos.Select(s => new {
            s.Id,
            s.Descricao,
            s.DataCadastro,
            s.Status,
            s.MotoId,
            Colaborador = s.Colaborador != null ? new
            {
                s.Colaborador.Id,
                s.Colaborador.Nome,
                s.Colaborador.Matricula,
                s.Colaborador.Email
            } : null
        }));
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Cadastra um novo serviço",
        Description = "Cadastra um novo serviço no sistema e retorna os dados cadastrados."
    )]
    [SwaggerRequestExample(typeof(ServicoDTO), typeof(ServicoRequestSample))]
    [SwaggerResponse(statusCode: 200, description: "Serviço salvo com sucesso", type: typeof(ServicoEntity))]
    [SwaggerResponseExample(statusCode: 200, typeof(ServicoResponseSample))]
    public async Task<IActionResult> Post(ServicoDTO dto)
    {
        try
        {
            var servicoCadastrado = await _servicoService.AdicionarServicoAsync(dto);
            return Ok(servicoCadastrado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza um serviço",
        Description = "Edita os dados de um serviço já cadastrado com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Serviço atualizado com sucesso", type: typeof(ServicoEntity))]
    [SwaggerResponse(statusCode: 400, description: "Erro na requisição (validação ou dados inválidos)")]
    [SwaggerResponse(statusCode: 404, description: "Serviço não encontrado")]
    [SwaggerRequestExample(typeof(ServicoDTO), typeof(ServicoRequestSample))]
    [SwaggerResponseExample(statusCode: 200, typeof(ServicoResponseSample))]
    public async Task<IActionResult> Put(long id, ServicoDTO dto)
    {
        try
        {
            var servicoEditado = await _servicoService.EditarServicoAsync(id, dto);
            if (servicoEditado is null)
                return NotFound();

            return Ok(servicoEditado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Remove um serviço",
        Description = "Exclui permanentemente um serviço com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Serviço removido com sucesso")]
    [SwaggerResponse(statusCode: 404, description: "Serviço não encontrado")]
    public async Task<IActionResult> Delete(long id)
    {
        var servico = await _servicoService.DeletarServicoAsync(id);

        if (servico is null)
            return NotFound();

        return Ok(servico);
    }
}

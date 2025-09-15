using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Doc.Samples;
using mototrack_backend_rest_dotnet.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MotoController : ControllerBase
{
    private readonly IMotoService _motoService;

    public MotoController(IMotoService motoService)
    {
        _motoService = motoService;
    }

    [HttpGet]
    [SwaggerOperation(
            Summary = "Lista de motos",
            Description = "Retorna a lista completa de motos cadastradas."
        )]
    [SwaggerResponse(statusCode: 200, description: "Lista retornada com sucesso", type: typeof(IEnumerable<MotoEntity>))]
    [SwaggerResponse(statusCode: 204, description: "Lista não tem dados")]
    [SwaggerResponseExample(statusCode: 200, typeof(MotoResponseListSample))]
    [EnableRateLimiting("MotoTrack")]
    public async Task<IActionResult> Get(int deslocamento = 0, int registrosRetornados = 10)
    {
        var result = await _motoService.ObterTodasMotosAsync(deslocamento, registrosRetornados);

        if (!result.Data.Any())
            return NoContent();

        var hateaos = new
        {
            data = result.Data.Select(m => new {
                m.Id,
                m.Placa,
                m.Chassi,
                m.Modelo,
                m.Status,
                Servicos = m.Servicos.Select(s => new ServicoResponseDTO
                {
                    Id = s.Id,
                    Descricao = s.Descricao,
                    DataCadastro = s.DataCadastro,
                    Status = s.Status,
                    MotoId = s.MotoId,
                    Colaborador = s.Colaborador == null ? null : new ColaboradorResponseDTO
                    {
                        Id = s.Colaborador.Id,
                        Nome = s.Colaborador.Nome,
                        Matricula = s.Colaborador.Matricula,
                        Email = s.Colaborador.Email
                    }
                }),
                links = new
                {
                    self = Url.Action(nameof(GetId), "Moto", new { id = m.Id }, Request.Scheme),
                }
            }),
            links = new
            {
                self = Url.Action(nameof(GetId), "Moto", null),
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
            Summary = "Obtém uma moto pelo ID",
            Description = "Retorna a moto correspondente ao ID informado."
        )]
    [SwaggerResponse(statusCode: 200, description: "Moto encontrada", type: typeof(MotoEntity))]
    [SwaggerResponse(statusCode: 404, description: "Moto não encontrada")]
    [SwaggerResponseExample(statusCode: 200, typeof(MotoResponseSample))]
    public async Task<IActionResult> GetId(long id)
    {
        var moto = await _motoService.ObterMotoPorIdAsync(id);

        if (moto is null)
            return NotFound();

        var response = new
        {
            moto.Id,
            moto.Placa,
            moto.Chassi,
            moto.Modelo,
            moto.Status,
            Servicos = moto.Servicos.Select(s => new ServicoResponseDTO
            {
                Id = s.Id,
                Descricao = s.Descricao,
                DataCadastro = s.DataCadastro,
                Status = s.Status,
                MotoId = s.MotoId,
                Colaborador = s.Colaborador == null ? null : new ColaboradorResponseDTO
                {
                    Id = s.Colaborador.Id,
                    Nome = s.Colaborador.Nome,
                    Matricula = s.Colaborador.Matricula,
                    Email = s.Colaborador.Email
                }
            })
        };

        return Ok(response);
    }
}

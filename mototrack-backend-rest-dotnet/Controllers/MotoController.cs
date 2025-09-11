using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using mototrack_backend_rest_dotnet.Doc.Samples;
using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Controllers;

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
                m.Servicos,
                links = new
                {
                    self = Url.Action(nameof(GetId), "Moto", new { id = m.Id }, Request.Scheme),
                    put = Url.Action(nameof(Put), "Moto", new { id = m.Id }, Request.Scheme),
                    delete = Url.Action(nameof(Delete), "Moto", new { id = m.Id }, Request.Scheme)
                }
            }),
            links = new
            {
                self = Url.Action(nameof(GetId), "Moto", null),
                post = Url.Action(nameof(Post), "Moto", null, Request.Scheme),
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

        return Ok(moto);
    }

    [HttpPost]
    [SwaggerOperation(
            Summary = "Cadastra uma nova moto",
            Description = "Cadastra uma nova moto no sistema e retorna os dados cadastrados."
        )]
    [SwaggerRequestExample(typeof(MotoDTO), typeof(MotoRequestSample))]
    [SwaggerResponse(statusCode: 200, description: "Loja salva com sucesso", type: typeof(MotoEntity))]
    [SwaggerResponseExample(statusCode: 200, typeof(MotoResponseSample))]
    public async Task<IActionResult> Post(MotoDTO dto)
    {
        try
        {
            var motoCadastrada = await _motoService.AdicionarMotoAsync(dto);
            return Ok(motoCadastrada);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza uma moto",
        Description = "Edita os dados de uma moto já cadastrada com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Moto atualizada com sucesso", type: typeof(MotoEntity))]
    [SwaggerResponse(statusCode: 400, description: "Erro na requisição (validação ou dados inválidos)")]
    [SwaggerResponse(statusCode: 404, description: "Moto não encontrada")]
    [SwaggerRequestExample(typeof(MotoDTO), typeof(MotoRequestSample))]
    [SwaggerResponseExample(statusCode: 200, typeof(MotoResponseSample))]
    public async Task<IActionResult> Put(int id, MotoDTO dto)
    {
        try
        {
            var motoEditada = await _motoService.EditarMotoAsync(id, dto);
            if (motoEditada is null)
                return NotFound();

            return Ok(motoEditada);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Remove uma moto",
        Description = "Exclui permanentemente uma moto com base no ID informado."
    )]
    [SwaggerResponse(statusCode: 200, description: "Moto removida com sucesso")]
    [SwaggerResponse(statusCode: 404, description: "Moto não encontrada")]
    public async Task<IActionResult> Delete(int id)
    {
        var moto = await _motoService.DeletarMotoAsync(id);

        if (moto is null)
            return NotFound();

        return Ok(moto);
    }
}

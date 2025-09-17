using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Mappers;
using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Domain.Entities;
using mototrack_backend_rest_dotnet.Domain.Interfaces;

namespace mototrack_backend_rest_dotnet.Application.Services;

public class PecaService : IPecaService
{
    private readonly IPecaRepository _pecaRepository;

    public PecaService(IPecaRepository pecaRepository)
    {
        _pecaRepository = pecaRepository;
    }

    public async Task<PageResultModel<IEnumerable<PecaEntity>>> ObterTodasPecasAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var pecas = await _pecaRepository.ObterTodasPecasAsync(deslocamento, registrosRetornados);
        return pecas;
    }

    public async Task<PecaEntity?> ObterPecaPorIdAsync(long id)
    {
        return await _pecaRepository.ObterPecaPorIdAsync(id);
    }

    public async Task<PecaEntity?> AdicionarPecaAsync(PecaDTO pecaDTO)
    {
        return await _pecaRepository.AdicionarPecaAsync(pecaDTO.ToPecaEntity());
    }

    public async Task<PecaEntity?> EditarPecaAsync(long id, PecaDTO novaPecaDTO)
    {
        var pecaExistente = await _pecaRepository.ObterPecaPorIdAsync(id);

        if (pecaExistente is null)
            return null;

        return await _pecaRepository.EditarPecaAsync(id, novaPecaDTO.ToPecaEntity());
    }

    public async Task<PecaEntity?> DeletarPecaAsync(long id)
    {
        var peca = await _pecaRepository.ObterPecaPorIdAsync(id);

        if (peca == null)
            return null;

        return await _pecaRepository.DeletarPecaAsync(id);
    }
}

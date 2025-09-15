using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Mappers;
using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Domain.Entities;
using mototrack_backend_rest_dotnet.Domain.Interfaces;

namespace mototrack_backend_rest_dotnet.Application.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _colaboradorRepository;

    public ColaboradorService(IColaboradorRepository colaboradorRepository)
    {
        _colaboradorRepository = colaboradorRepository;
    }

    public async Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var colaboradores = await _colaboradorRepository.ObterTodosColaboradoresAsync(deslocamento, registrosRetornados);
        return colaboradores;
    }

    public async Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(long id)
    {
        return await _colaboradorRepository.ObterColaboradorPorIdAsync(id);
    }

    public async Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorDTO colaboradorDTO)
    {
        return await _colaboradorRepository.AdicionarColaboradorAsync(colaboradorDTO.ToColaboradorEntity());
    }

    public async Task<ColaboradorEntity?> EditarColaboradorAsync(long id, ColaboradorDTO novoColaboradorDTO)
    {
        var colaboradorExistente = await _colaboradorRepository.ObterColaboradorPorIdAsync(id);

        if (colaboradorExistente is null)
            return null;

        return await _colaboradorRepository.EditarColaboradorAsync(id, novoColaboradorDTO.ToColaboradorEntity());
    }

    public async Task<ColaboradorEntity?> DeletarColaboradorAsync(long id)
    {
        var colaborador = await _colaboradorRepository.ObterColaboradorPorIdAsync(id);

        if (colaborador == null)
            return null;

        return await _colaboradorRepository.DeletarColaboradorAsync(id);
    }
}

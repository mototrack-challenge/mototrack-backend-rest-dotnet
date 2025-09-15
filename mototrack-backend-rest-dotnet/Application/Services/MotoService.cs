using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Domain.Entities;
using mototrack_backend_rest_dotnet.Domain.Interfaces;

namespace mototrack_backend_rest_dotnet.Application.Services;

public class MotoService : IMotoService
{
    private readonly IMotoRepository _motoRepository;

    public MotoService(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<PageResultModel<IEnumerable<MotoEntity>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var motos = await _motoRepository.ObterTodasMotosAsync(deslocamento, registrosRetornados);
        return motos;
    }

    public async Task<MotoEntity?> ObterMotoPorIdAsync(long id)
    {
        return await _motoRepository.ObterMotoPorIdAsync(id);
    }

}

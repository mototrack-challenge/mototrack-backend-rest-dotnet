using mototrack_backend_rest_dotnet.Data.Repositories.Interface;
using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Services.Interface;

namespace mototrack_backend_rest_dotnet.Services;

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

    public async Task<MotoEntity?> ObterMotoPorIdAsync(int id)
    {
        return await _motoRepository.ObterMotoPorIdAsync(id);
    }

    public async Task<MotoEntity?> AdicionarMotoAsync(MotoEntity moto)
    {
        if (await _motoRepository.ExistePorPlacaAsync(moto.Placa))
            throw new InvalidOperationException("Já existe uma moto cadastrada com essa placa.");

        if (await _motoRepository.ExistePorChassiAsync(moto.Chassi))
            throw new InvalidOperationException("Já existe uma moto cadastrada com esse chassi.");

        return await _motoRepository.AdicionarMotoAsync(moto);
    }

    public async Task<MotoEntity?> EditarMotoAsync(int id, MotoEntity moto)
    {
        return await _motoRepository.EditarMotoAsync(id, moto);
    }

    public async Task<MotoEntity?> DeletarMotoAsync(int id)
    {
        return await _motoRepository.DeletarMotoAsync(id);
    }

}

using mototrack_backend_rest_dotnet.Data.Repositories.Interface;
using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Mappers;
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

    public async Task<MotoEntity?> AdicionarMotoAsync(MotoDTO dto)
    {
        if (await _motoRepository.ExistePorPlacaAsync(dto.Placa))
            throw new InvalidOperationException("Já existe uma moto cadastrada com essa placa.");

        if (await _motoRepository.ExistePorChassiAsync(dto.Chassi))
            throw new InvalidOperationException("Já existe uma moto cadastrada com esse chassi.");


        return await _motoRepository.AdicionarMotoAsync(dto.ToMotoEntity());
    }

    public async Task<MotoEntity?> EditarMotoAsync(int id, MotoDTO dto)
    {
        var motoExistente = await _motoRepository.ObterMotoPorIdAsync(id);

        if (motoExistente is null)
            return null;

        if (await _motoRepository.ExistePorPlacaAsync(dto.Placa, id))
            throw new InvalidOperationException("Já existe uma moto cadastrada com essa placa.");

        if (await _motoRepository.ExistePorChassiAsync(dto.Chassi, id))
            throw new InvalidOperationException("Já existe uma moto cadastrada com esse chassi.");

        return await _motoRepository.EditarMotoAsync(id, dto.ToMotoEntity());
    }

    public async Task<MotoEntity?> DeletarMotoAsync(int id)
    {
        var moto = await _motoRepository.ObterMotoPorIdAsync(id);

        if (moto == null)
            return null;

        return await _motoRepository.DeletarMotoAsync(id);
    }

}

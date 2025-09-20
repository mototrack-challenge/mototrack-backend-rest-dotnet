using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Domain.Entities;
using mototrack_backend_rest_dotnet.Domain.Interfaces;
using mototrack_backend_rest_dotnet.Infrastructure.Data.Repositories;
using System.Net;

namespace mototrack_backend_rest_dotnet.Application.Services;

public class MotoService : IMotoService
{
    private readonly IMotoRepository _motoRepository;

    public MotoService(IMotoRepository motoRepository)
    {
        _motoRepository = motoRepository;
    }

    public async Task<OperationResult<PageResultModel<IEnumerable<MotoEntity>>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        try
        {
            var result = await _motoRepository.ObterTodasMotosAsync(deslocamento, registrosRetornados);

            if (!result.Data.Any())
                return OperationResult<PageResultModel<IEnumerable<MotoEntity>>>.Failure("Não existe conteudo para motos", (int)HttpStatusCode.NotFound);

            return OperationResult<PageResultModel<IEnumerable<MotoEntity>>>.Success(result);
        }
        catch (Exception)
        {
            return OperationResult<PageResultModel<IEnumerable<MotoEntity>>>.Failure("Ocorreu um erro ao buscar as motos");
        }
    }

    public async Task<OperationResult<MotoEntity?>> ObterMotoPorIdAsync(long id)
    {
        try
        {
            var result = await _motoRepository.ObterMotoPorIdAsync(id);

            if (result is null)
                return OperationResult<MotoEntity?>.Failure("Moto não encontrada", (int)HttpStatusCode.NotFound);

            return OperationResult<MotoEntity?>.Success(result);
        }
        catch (Exception)
        {
            return OperationResult<MotoEntity?>.Failure("Ocorreu um erro ao buscar a moto");
        }
    }

}

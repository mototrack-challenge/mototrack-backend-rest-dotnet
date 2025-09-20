using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IMotoService
{
    Task<OperationResult<PageResultModel<IEnumerable<MotoEntity>>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<OperationResult<MotoEntity?>> ObterMotoPorIdAsync(long id);
}

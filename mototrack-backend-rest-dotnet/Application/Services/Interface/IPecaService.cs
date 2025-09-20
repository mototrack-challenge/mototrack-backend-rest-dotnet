using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IPecaService
{
    Task<OperationResult<PageResultModel<IEnumerable<PecaEntity>>>> ObterTodasPecasAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<OperationResult<PecaEntity?>> ObterPecaPorIdAsync(long id);
    Task<OperationResult<PecaEntity?>> AdicionarPecaAsync(PecaDTO pecaDTO);
    Task<OperationResult<PecaEntity?>> EditarPecaAsync(long id, PecaDTO novaPecaDTO);
    Task<OperationResult<PecaEntity?>> DeletarPecaAsync(long id);
}

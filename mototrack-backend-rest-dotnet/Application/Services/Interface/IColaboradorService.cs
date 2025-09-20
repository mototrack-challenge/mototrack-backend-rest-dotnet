using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IColaboradorService
{
    Task<OperationResult<PageResultModel<IEnumerable<ColaboradorEntity>>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<OperationResult<ColaboradorEntity?>> ObterColaboradorPorIdAsync(long id);
    Task<OperationResult<ColaboradorEntity?>> AdicionarColaboradorAsync(ColaboradorDTO colaboradorDTO);
    Task<OperationResult<ColaboradorEntity?>> EditarColaboradorAsync(long id, ColaboradorDTO novoColaboradorDTO);
    Task<OperationResult<ColaboradorEntity?>> DeletarColaboradorAsync(long id);
}

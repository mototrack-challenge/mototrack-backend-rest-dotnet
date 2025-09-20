using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IServicoService
{
    Task<OperationResult<PageResultModel<IEnumerable<ServicoEntity>>>> ObterTodosServicosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<OperationResult<ServicoEntity?>> ObterServicoPorIdAsync(long id);
    Task<OperationResult<IEnumerable<ServicoEntity>>> ObterServicosPorMotoIdAsync(long motoId);
    Task<OperationResult<ServicoEntity?>> AdicionarServicoAsync(ServicoDTO servicoDTO);
    Task<OperationResult<ServicoEntity?>> EditarServicoAsync(long id, ServicoDTO novoServicoDTO);
    Task<OperationResult<ServicoEntity?>> DeletarServicoAsync(long id);
}

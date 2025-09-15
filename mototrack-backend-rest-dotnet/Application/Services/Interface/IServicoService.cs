using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IServicoService
{
    Task<PageResultModel<IEnumerable<ServicoEntity>>> ObterTodosServicosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ServicoEntity?> ObterServicoPorIdAsync(long id);
    Task<IEnumerable<ServicoEntity>> ObterServicosPorMotoIdAsync(long motoId);
    Task<ServicoEntity?> AdicionarServicoAsync(ServicoDTO servicoDTO);
    Task<ServicoEntity?> EditarServicoAsync(long id, ServicoDTO novoServicoDTO);
    Task<ServicoEntity?> DeletarServicoAsync(long id);
}

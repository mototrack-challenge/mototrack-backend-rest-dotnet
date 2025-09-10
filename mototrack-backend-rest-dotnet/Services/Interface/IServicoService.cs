using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Services.Interface;

public interface IServicoService
{
    Task<PageResultModel<IEnumerable<ServicoEntity>>> ObterTodosServicosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ServicoEntity?> ObterServicoPorIdAsync(long id);
    Task<ServicoEntity?> AdicionarServicoAsync(ServicoDTO servicoDTO);
    Task<ServicoEntity?> EditarServicoAsync(long id, ServicoDTO novoServicoDTO);
    Task<ServicoEntity?> DeletarServicoAsync(long id);
}

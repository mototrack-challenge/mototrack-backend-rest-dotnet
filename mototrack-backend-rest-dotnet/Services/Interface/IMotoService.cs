using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Services.Interface;

public interface IMotoService
{
    Task<PageResultModel<IEnumerable<MotoEntity>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<MotoEntity?> ObterMotoPorIdAsync(long id);
    Task<MotoEntity?> AdicionarMotoAsync(MotoDTO motoDto);
    Task<MotoEntity?> EditarMotoAsync(int id, MotoDTO novaMotoDto);
    Task<MotoEntity?> DeletarMotoAsync(int id);
}

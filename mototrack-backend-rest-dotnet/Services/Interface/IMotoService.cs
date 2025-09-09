using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Services.Interface;

public interface IMotoService
{
    Task<PageResultModel<IEnumerable<MotoEntity>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<MotoEntity?> ObterMotoPorIdAsync(int id);
    Task<MotoEntity?> AdicionarMotoAsync(MotoEntity moto);
    Task<MotoEntity?> EditarMotoAsync(int id, MotoEntity novaMoto);
    Task<MotoEntity?> DeletarMotoAsync(int id);
}

using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.Repositories.Interface;

public interface IMotoRepository
{
    Task<PageResultModel<IEnumerable<MotoEntity>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<MotoEntity?> ObterMotoPorIdAsync(int id);
    Task<MotoEntity?> AdicionarMotoAsync(MotoEntity moto);
    Task<MotoEntity?> EditarMotoAsync(int id, MotoEntity novaMoto);
    Task<MotoEntity?> DeletarMotoAsync(int id);
    //Task<bool> ExistePorPlacaAsync(string placa, int? idIgnorado = null);
    //Task<bool> ExistePorChassiAsync(string chassi, int? idIgnorado = null);
}

using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.Repositories.Interface;

public interface IColaboradorRepository
{
    Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(long id);
    Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorEntity colaborador);
    Task<ColaboradorEntity?> EditarColaboradorAsync(long id, ColaboradorEntity novoColaborador);
    Task<ColaboradorEntity?> DeletarColaboradorAsync(long id);
}

using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.Repositories.Interface;

public interface IColaboradorRepository
{
    Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(int id);
    Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorEntity colaborador);
    Task<ColaboradorEntity?> EditarColaboradorAsync(int id, ColaboradorEntity novoColaborador);
    Task<ColaboradorEntity?> DeletarColaboradorAsync(int id);
}

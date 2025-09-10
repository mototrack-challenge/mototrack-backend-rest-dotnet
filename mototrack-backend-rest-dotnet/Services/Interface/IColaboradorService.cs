using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Services.Interface;

public interface IColaboradorService
{
    Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(long id);
    Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorDTO colaboradorDTO);
    Task<ColaboradorEntity?> EditarColaboradorAsync(long id, ColaboradorDTO novoColaboradorDTO);
    Task<ColaboradorEntity?> DeletarColaboradorAsync(long id);
}

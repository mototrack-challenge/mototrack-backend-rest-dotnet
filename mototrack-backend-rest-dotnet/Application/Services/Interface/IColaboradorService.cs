using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IColaboradorService
{
    Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(long id);
    Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorDTO colaboradorDTO);
    Task<ColaboradorEntity?> EditarColaboradorAsync(long id, ColaboradorDTO novoColaboradorDTO);
    Task<ColaboradorEntity?> DeletarColaboradorAsync(long id);
}

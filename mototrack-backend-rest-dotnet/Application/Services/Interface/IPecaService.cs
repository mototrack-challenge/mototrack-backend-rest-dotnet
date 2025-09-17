using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Services.Interface;

public interface IPecaService
{
    Task<PageResultModel<IEnumerable<PecaEntity>>> ObterTodasPecasAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<PecaEntity?> ObterPecaPorIdAsync(long id);
    Task<PecaEntity?> AdicionarPecaAsync(PecaDTO pecaDTO);
    Task<PecaEntity?> EditarPecaAsync(long id, PecaDTO novaPecaDTO);
    Task<PecaEntity?> DeletarPecaAsync(long id);
}

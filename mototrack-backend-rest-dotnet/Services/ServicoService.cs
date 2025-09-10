using mototrack_backend_rest_dotnet.Data.Repositories.Interface;
using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Mappers;
using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Services.Interface;

namespace mototrack_backend_rest_dotnet.Services;

public class ServicoService : IServicoService
{
    private readonly IServicoRepository _servicoRepository;

    public ServicoService(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<PageResultModel<IEnumerable<ServicoEntity>>> ObterTodosServicosAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var servicos = await _servicoRepository.ObterTodosServicosAsync(deslocamento, registrosRetornados);
        return servicos;
    }

    public async Task<ServicoEntity?> ObterServicoPorIdAsync(long id)
    {
        return await _servicoRepository.ObterServicoPorIdAsync(id);
    }

    public async Task<ServicoEntity?> AdicionarServicoAsync(ServicoDTO servicoDTO)
    {
        return await _servicoRepository.AdicionarServicoAsync(servicoDTO.ToServicoEntity());
    }

    public async Task<ServicoEntity?> EditarServicoAsync(long id, ServicoDTO novoServicoDTO)
    {
        var servicoExistente = await _servicoRepository.ObterServicoPorIdAsync(id);

        if (servicoExistente is null)
            return null;

        return await _servicoRepository.EditarServicoAsync(id, novoServicoDTO.ToServicoEntity());
    }

    public async Task<ServicoEntity?> DeletarServicoAsync(long id)
    {
        var servico = await _servicoRepository.ObterServicoPorIdAsync(id);

        if (servico == null)
            return null;

        return await _servicoRepository.DeletarServicoAsync(id);
    }
}

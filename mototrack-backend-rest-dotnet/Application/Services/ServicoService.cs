using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Mappers;
using mototrack_backend_rest_dotnet.Application.Services.Interface;
using mototrack_backend_rest_dotnet.Domain.Entities;
using mototrack_backend_rest_dotnet.Domain.Interfaces;

namespace mototrack_backend_rest_dotnet.Application.Services;

public class ServicoService : IServicoService
{
    private readonly IServicoRepository _servicoRepository;
    private readonly IMotoRepository _motoRepository;

    public ServicoService(IServicoRepository servicoRepository, IMotoRepository motoRepository)
    {
        _servicoRepository = servicoRepository;
        _motoRepository = motoRepository;
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

    public async Task<IEnumerable<ServicoEntity>> ObterServicosPorMotoIdAsync(long motoId)
    {
        var moto = await _motoRepository.ObterMotoPorIdAsync(motoId);

        if (moto is null)
            return null;

        return await _servicoRepository.ObterServicosPorMotoIdAsync(motoId);
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

using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Mappers;

public static class ServicoMapper
{
    public static ServicoEntity ToServicoEntity(this ServicoDTO dto)
    {
        return new ServicoEntity
        {
            Descricao = dto.Descricao,
            Status = dto.Status,
            MotoId = dto.MotoId,
            ColaboradorId = dto.ColaboradorId
        };
    }
}

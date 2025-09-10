using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Mappers;

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

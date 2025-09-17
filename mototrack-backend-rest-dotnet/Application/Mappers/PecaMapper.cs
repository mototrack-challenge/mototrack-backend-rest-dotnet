using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Mappers;

public static class PecaMapper
{
    public static PecaEntity ToColaboradorEntity(this PecaDTO dto)
    {
        return new PecaEntity
        {
            Nome = dto.Nome,
            Codigo = dto.Codigo,
            Descricao = dto.Descricao,
            QuantidadeEstoque = dto.QuantidadeEstoque
        };
    }
}

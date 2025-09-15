using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Mappers;

public static class ColaboradorMapper
{
    public static ColaboradorEntity ToColaboradorEntity(this ColaboradorDTO dto)
    {
        return new ColaboradorEntity
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Matricula = dto.Matricula
        };
    }
}

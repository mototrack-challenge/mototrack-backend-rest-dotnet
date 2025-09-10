using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Mappers;

public static class ColaboradorMapper
{
    public static ColaboradorEntity ToMotoEntity(this ColaboradorDTO dto)
    {
        return new ColaboradorEntity
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Matricula = dto.Matricula
        };
    }
}

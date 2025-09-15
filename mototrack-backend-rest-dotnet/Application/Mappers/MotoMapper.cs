using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Application.Mappers;

public static class MotoMapper
{
    public static MotoEntity ToMotoEntity(this MotoDTO dto)
    {
        return new MotoEntity
        {
            Placa = dto.Placa,
            Chassi = dto.Chassi,
            Modelo = dto.Modelo,
            Status = dto.Status
        };
    }
}

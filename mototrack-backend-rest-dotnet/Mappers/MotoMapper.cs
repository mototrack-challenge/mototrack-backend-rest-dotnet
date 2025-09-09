using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Mappers;

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

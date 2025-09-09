using mototrack_backend_rest_dotnet.Models.Enums;

namespace mototrack_backend_rest_dotnet.Dtos;

public record MotoDTO(string Placa, string Chassi, ModeloMoto Modelo, StatusMoto Status);

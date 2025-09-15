using System.Text.Json.Serialization;

namespace mototrack_backend_rest_dotnet.Application.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusMoto
{
    MANUTENCAO,
    PRONTA_PARA_USO,
    AVALIACAO
}

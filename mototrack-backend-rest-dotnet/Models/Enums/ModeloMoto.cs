using System.Text.Json.Serialization;

namespace mototrack_backend_rest_dotnet.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ModeloMoto
{
    MOTTU_POP,
    MOTTU_SPORT,
    MOTTU_E
}

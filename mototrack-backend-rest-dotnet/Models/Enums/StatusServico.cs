using System.Text.Json.Serialization;

namespace mototrack_backend_rest_dotnet.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusServico
{
    Pendente = 0,
    EmAndamento = 1,
    Concluido = 2,
}

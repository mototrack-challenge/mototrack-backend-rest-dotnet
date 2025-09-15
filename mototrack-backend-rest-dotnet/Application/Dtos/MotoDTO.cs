using mototrack_backend_rest_dotnet.Application.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mototrack_backend_rest_dotnet.Application.Dtos;

public class MotoDTO
{
    [Required]
    public string Placa { get; set; }

    [Required]
    public string Chassi { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ModeloMoto Modelo { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public StatusMoto Status { get; set; }
}

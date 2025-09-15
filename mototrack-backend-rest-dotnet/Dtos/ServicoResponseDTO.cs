using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;

namespace mototrack_backend_rest_dotnet.Dtos;

public class ServicoResponseDTO
{
    public long Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public StatusServico Status { get; set; }
    public long MotoId { get; set; }
    public ColaboradorResponseDTO Colaborador { get; set; }
}

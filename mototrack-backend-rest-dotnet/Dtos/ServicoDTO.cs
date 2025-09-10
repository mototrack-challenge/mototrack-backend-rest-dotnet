using mototrack_backend_rest_dotnet.Models.Enums;

namespace mototrack_backend_rest_dotnet.Dtos;

public record ServicoDTO(string Descricao, StatusServico Status, long MotoId, long ColaboradorId);

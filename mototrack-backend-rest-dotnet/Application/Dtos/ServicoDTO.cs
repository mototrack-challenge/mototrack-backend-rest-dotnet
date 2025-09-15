using mototrack_backend_rest_dotnet.Application.Enums;

namespace mototrack_backend_rest_dotnet.Application.Dtos;

public record ServicoDTO(string Descricao, StatusServico Status, long MotoId, long ColaboradorId);

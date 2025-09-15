using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ServicoRequestSample : IExamplesProvider<ServicoDTO>
{
    public ServicoDTO GetExamples()
    {
        return new ServicoDTO(
            Descricao: "Troca de óleo",
            Status: StatusServico.Pendente,
            MotoId: 2,
            ColaboradorId: 1
        );
    }
}

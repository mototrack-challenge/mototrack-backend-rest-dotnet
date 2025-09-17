using mototrack_backend_rest_dotnet.Application.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class PecaRequestSample : IExamplesProvider<PecaDTO>
{
    public PecaDTO GetExamples()
    {
        return new PecaDTO("Filtro de Óleo", "PF456", "Filtro de óleo compatível com as motos", 30);
    }
}

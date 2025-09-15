using mototrack_backend_rest_dotnet.Application.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ColaboradorRequestSample : IExamplesProvider<ColaboradorDTO>
{
    public ColaboradorDTO GetExamples()
    {
        return new ColaboradorDTO("Felipe Sora", "620184901", "felipe@email.com");
    }
}

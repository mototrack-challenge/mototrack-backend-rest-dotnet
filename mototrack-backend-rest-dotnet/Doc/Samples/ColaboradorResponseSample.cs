using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ColaboradorResponseSample : IExamplesProvider<ColaboradorEntity>
{
    public ColaboradorEntity GetExamples()
    {
        return new ColaboradorEntity
        {
            Id = 1,
            Nome = "Felipe Sora",
            Matricula = "620184901",
            Email = "felipe@email.com"
        };
    }
}

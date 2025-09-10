using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ColaboradorResponseListSample : IExamplesProvider<IEnumerable<ColaboradorEntity>>
{
    public IEnumerable<ColaboradorEntity> GetExamples()
    {
        return new List<ColaboradorEntity>
        {
            new ColaboradorEntity
            {
                Id = 1,
                Nome = "Felipe Sora",
                Matricula = "620184901",
                Email = "felipe@email.com"
            },
            new ColaboradorEntity
            {
                Id = 2,
                Nome = "Augusto Lopes",
                Matricula = "620138001",
                Email = "augusto@email.com"
            },
        };
    }
}

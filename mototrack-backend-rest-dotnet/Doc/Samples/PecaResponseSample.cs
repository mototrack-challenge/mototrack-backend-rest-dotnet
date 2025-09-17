using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using mototrack_backend_rest_dotnet.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class PecaResponseSample : IExamplesProvider<PecaEntity>
{
    public PecaEntity GetExamples()
    {
        return new PecaEntity   
        {
            Id = 1,
            Nome = "Filtro de Óleo",
            Codigo = "PF456",
            Descricao = "Filtro de óleo compatível com as motos",
            QuantidadeEstoque = 30
        };
    }
}

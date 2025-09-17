using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using mototrack_backend_rest_dotnet.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class PecaResponseListSample : IExamplesProvider<IEnumerable<PecaEntity>>
{
    public IEnumerable<PecaEntity> GetExamples()
    {
        return new List<PecaEntity>
        {
            new PecaEntity
            {
                Id = 1,
                Nome = "Filtro de Óleo",
                Codigo = "PF456",
                Descricao = "Filtro de óleo compatível com as motos",
                QuantidadeEstoque = 30
            },
            new PecaEntity
            {
                Id = 2,
                Nome = "Bateria 12V",
                Codigo = "BT101",
                Descricao = "Filtro de óleo compatível com as motosBateria selada de 12V, compatível com motos-pop",
                QuantidadeEstoque = 8
            }
        };
    }
}

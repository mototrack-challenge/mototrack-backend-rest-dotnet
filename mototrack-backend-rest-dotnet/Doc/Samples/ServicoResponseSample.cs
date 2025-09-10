using mototrack_backend_rest_dotnet.Models.Enums;
using mototrack_backend_rest_dotnet.Models;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ServicoResponseSample : IExamplesProvider<ServicoEntity>
{
    public ServicoEntity GetExamples()
    {
        return new ServicoEntity
        {
            Id = 1,
            Descricao = "Troca de óleo",
            DataCadastro = DateTime.Now,
            Status = StatusServico.EmAndamento,
            MotoId = 2,
            ColaboradorId = 1
        };
    }
}

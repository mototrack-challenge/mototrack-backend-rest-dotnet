using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ServicoResponseListSample : IExamplesProvider<IEnumerable<ServicoEntity>>
{
    public IEnumerable<ServicoEntity> GetExamples()
    {
        return new List<ServicoEntity>
        {
            new ServicoEntity
            {
                Id = 1,
                Descricao = "Troca de óleo",
                DataCadastro = DateTime.Now,
                Status = StatusServico.EmAndamento,
                MotoId = 2,
                ColaboradorId = 1
            },
            new ServicoEntity
            {
                Id = 2,
                Descricao = "Revisão do motor",
                DataCadastro = DateTime.Now,
                Status = StatusServico.Pendente,
                MotoId = 3,
                ColaboradorId = 2
            }
        };
    }
}
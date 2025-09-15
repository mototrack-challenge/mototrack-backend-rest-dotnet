using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class MotoResponseSample : IExamplesProvider<MotoResponseDTO>
{
    public MotoResponseDTO GetExamples()
    {
        return new MotoResponseDTO
        {
            Id = 1,
            Placa = "ABC1234",
            Chassi = "9C2JC4110VR123456",
            Modelo = ModeloMoto.MOTTU_POP,
            Status = StatusMoto.PRONTA_PARA_USO,
            Servicos = new List<ServicoResponseDTO>
            {
                new ServicoResponseDTO
                {
                    Id = 1,
                    Descricao = "Troca de óleo",
                    DataCadastro = DateTime.Now,
                    Status = StatusServico.EmAndamento,
                    MotoId = 1,
                    Colaborador = new ColaboradorResponseDTO
                    {
                        Id = 1,
                        Nome = "Felipe Sora",
                        Matricula = "620184901",
                        Email = "felipe@email.com"
                    }
                }
            }
        };
    }
}

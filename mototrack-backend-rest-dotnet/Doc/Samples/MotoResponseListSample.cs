using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class MotoResponseListSample : IExamplesProvider<IEnumerable<MotoEntity>>
{
    public IEnumerable<MotoEntity> GetExamples()
    {
        return new List<MotoEntity>
            {
                new MotoEntity
                {
                    Id = 1,
                    Placa = "ABC1234",
                    Chassi = "9C2JC4110VR123456",
                    Modelo = ModeloMoto.MOTTU_POP,
                    Status = StatusMoto.DISPONIVEL
                },
                new MotoEntity
                {
                    Id = 2,
                    Placa = "DEF5678",
                    Chassi = "5C23JC4110VR1234B",
                    Modelo = ModeloMoto.MOTTU_SPORT,
                    Status = StatusMoto.MANUTENCAO
                },
            };
    }
}

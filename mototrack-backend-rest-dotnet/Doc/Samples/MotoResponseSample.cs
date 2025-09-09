using mototrack_backend_rest_dotnet.Models;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class MotoResponseSample : IExamplesProvider<MotoEntity>
{
    public MotoEntity GetExamples()
    {
        return new MotoEntity
        {
            Id = 1,
            Placa = "ABC1234",
            Chassi = "9C2JC4110VR123456",
            Modelo = ModeloMoto.MOTTU_POP,
            Status = StatusMoto.DISPONIVEL
        };
    }
}

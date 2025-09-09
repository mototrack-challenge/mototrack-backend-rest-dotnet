using mototrack_backend_rest_dotnet.Dtos;
using mototrack_backend_rest_dotnet.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class MotoRequestSample : IExamplesProvider<MotoDTO>
{
    public MotoDTO GetExamples()
    {
        return new MotoDTO("ABC1234", "9C2JC4110VR123456", ModeloMoto.MOTTU_POP, StatusMoto.DISPONIVEL);
    }
}

﻿using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class MotoRequestSample : IExamplesProvider<MotoDTO>
{
    public MotoDTO GetExamples()
    {
        return new MotoDTO
        {
            Placa = "ABC1234",
            Chassi = "9C2JC4110VR123456",
            Modelo = ModeloMoto.MOTTU_POP,
            Status = StatusMoto.DISPONIVEL
        };
    }
}

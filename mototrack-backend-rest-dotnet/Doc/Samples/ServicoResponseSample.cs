﻿using Swashbuckle.AspNetCore.Filters;
using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ServicoResponseSample : IExamplesProvider<ServicoResponseDTO>
{
    public ServicoResponseDTO GetExamples()
    {
        return new ServicoResponseDTO
        {
            Id = 1,
            Descricao = "Troca de óleo",
            DataCadastro = DateTime.Now,
            Status = StatusServico.EmAndamento,
            MotoId = 2,
            Colaborador = new ColaboradorResponseDTO
            {
                Id = 1,
                Nome = "Felipe Sora",
                Matricula = "620184901",
                Email = "felipe@email.com"
            }
        };
    }
}

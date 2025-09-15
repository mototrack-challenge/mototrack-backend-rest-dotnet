﻿using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ColaboradorResponseSample : IExamplesProvider<ColaboradorResponseDTO>
{
    public ColaboradorResponseDTO GetExamples()
    {
        return new ColaboradorResponseDTO
        {
            Id = 1,
            Nome = "Felipe Sora",
            Matricula = "620184901",
            Email = "felipe@email.com",
            Servicos = new List<ServicoResponseDTO>
            {
                new ServicoResponseDTO
                {
                    Id = 1,
                    Descricao = "Troca de óleo",
                    DataCadastro = DateTime.Now,
                    Status = StatusServico.EmAndamento,
                    MotoId = 1,
                }
            }
        };
    }
}

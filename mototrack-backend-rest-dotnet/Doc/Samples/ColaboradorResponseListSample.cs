﻿using mototrack_backend_rest_dotnet.Application.Dtos;
using mototrack_backend_rest_dotnet.Application.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace mototrack_backend_rest_dotnet.Doc.Samples;

public class ColaboradorResponseListSample : IExamplesProvider<IEnumerable<ColaboradorResponseDTO>>
{
    public IEnumerable<ColaboradorResponseDTO> GetExamples()
    {
        return new List<ColaboradorResponseDTO>
        {
            new ColaboradorResponseDTO
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
            },
            new ColaboradorResponseDTO
            {
                Id = 2,
                Nome = "Augusto Lopes",
                Matricula = "620138001",
                Email = "augusto@email.com",
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
            },
        };
    }
}

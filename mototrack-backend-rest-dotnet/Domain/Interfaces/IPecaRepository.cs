﻿using mototrack_backend_rest_dotnet.Domain.Entities;

namespace mototrack_backend_rest_dotnet.Domain.Interfaces;

public interface IPecaRepository
{
    Task<PageResultModel<IEnumerable<PecaEntity>>> ObterTodasPecasAsync(int deslocamento = 0, int registrosRetornados = 10);
    Task<PecaEntity?> ObterPecaPorIdAsync(long id);
    Task<PecaEntity?> AdicionarPecaAsync(PecaEntity peca);
    Task<PecaEntity?> EditarPecaAsync(long id, PecaEntity novaPeca);
    Task<PecaEntity?> DeletarPecaAsync(long id);
}

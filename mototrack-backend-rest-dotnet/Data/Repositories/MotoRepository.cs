using Microsoft.EntityFrameworkCore;
using mototrack_backend_rest_dotnet.Data.AppData;
using mototrack_backend_rest_dotnet.Data.Repositories.Interface;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.Repositories;

public class MotoRepository : IMotoRepository
{
    private readonly ApplicationContext _context;

    public MotoRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<PageResultModel<IEnumerable<MotoEntity>>> ObterTodasMotosAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var totalRegistros = await _context.Moto.CountAsync();

        var result = await _context
            .Moto
            .Include(m => m.Servicos)
                .ThenInclude(s => s.Colaborador)
            .OrderBy(m => m.Id)
            .Skip(deslocamento)
            .Take(registrosRetornados)
            .ToListAsync();

        return new PageResultModel<IEnumerable<MotoEntity>>
        {
            Data = result,
            Deslocamento = deslocamento,
            RegistrosRetornados = registrosRetornados,
            TotalRegistros = totalRegistros
        };
    }

    public async Task<MotoEntity?> ObterMotoPorIdAsync(long id)
    {
        var result = await _context
            .Moto
            .Include(m => m.Servicos)
                .ThenInclude(s => s.Colaborador)
            .FirstOrDefaultAsync(m => m.Id == id);

        return result;
    }
}

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

    public async Task<MotoEntity?> ObterMotoPorIdAsync(int id)
    {
        var result = await _context
            .Moto
            .FirstOrDefaultAsync(m => m.Id == id);

        return result;
    }

    public async Task<MotoEntity?> AdicionarMotoAsync(MotoEntity moto)
    {
        _context.Moto.Add(moto);
        await _context.SaveChangesAsync();

        return moto;
    }

    public async Task<MotoEntity?> EditarMotoAsync(int id, MotoEntity novaMoto)
    {
        var motoExistente = await _context.Moto.FirstOrDefaultAsync(m => m.Id == id);

        if (motoExistente is null)
            return null;

        motoExistente.Placa = novaMoto.Placa;
        motoExistente.Chassi = novaMoto.Chassi;
        motoExistente.Modelo = novaMoto.Modelo;
        motoExistente.Status = novaMoto.Status;

        await _context.SaveChangesAsync();
        return motoExistente;
    }

    public async Task<MotoEntity?> DeletarMotoAsync(int id)
    {
        var moto = await _context.Moto.FindAsync(id);

        if (moto is null)
            return null;

        _context.Moto.Remove(moto);
        await _context.SaveChangesAsync();
        return moto;
    }

    public async Task<bool> ExistePorPlacaAsync(string placa, int? idIgnorado = null)
    {
        return await _context.Moto
            .AnyAsync(m => m.Placa == placa && (!idIgnorado.HasValue || m.Id != idIgnorado.Value));
    }

    public async Task<bool> ExistePorChassiAsync(string chassi, int? idIgnorado = null)
    {
        return await _context.Moto
            .AnyAsync(m => m.Chassi == chassi && (!idIgnorado.HasValue || m.Id != idIgnorado.Value));
    }
}

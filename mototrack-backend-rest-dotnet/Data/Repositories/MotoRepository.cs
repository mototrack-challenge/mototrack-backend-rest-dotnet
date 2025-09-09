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
        _context.Moto.AddAsync(moto);
        _context.SaveChanges();

        return moto;
    }

    public async Task<MotoEntity?> EditarMotoAsync(int id, MotoEntity novaMoto)
    {
        var result = await _context.Moto.FirstOrDefaultAsync(m => m.Id == id);

        if (result is not null)
        {
            result.Placa = novaMoto.Placa;
            result.Chassi = novaMoto.Chassi;
            result.Modelo = novaMoto.Modelo;
            result.Status = novaMoto.Status;

            _context.Update(result);
            _context.SaveChanges();

            return result;
        }

        return null;
    }

    public async Task<MotoEntity?> DeletarMotoAsync(int id)
    {
        var result = await _context.Moto.FindAsync(id);

        if (result is not null)
        {
            _context.Remove(result);
            _context.SaveChanges();

            return result;
        }

        return null;
    }

    public async Task<bool> ExistePorPlacaAsync(string placa)
    {
        return await _context.Moto.AnyAsync(m => m.Placa == placa);
    }

    public async Task<bool> ExistePorChassiAsync(string chassi)
    {
        return await _context.Moto.AnyAsync(m => m.Chassi == chassi);
    }
}

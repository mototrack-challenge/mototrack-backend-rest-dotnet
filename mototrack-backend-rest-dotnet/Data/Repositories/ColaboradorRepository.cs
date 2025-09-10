using Microsoft.EntityFrameworkCore;
using mototrack_backend_rest_dotnet.Data.AppData;
using mototrack_backend_rest_dotnet.Data.Repositories.Interface;
using mototrack_backend_rest_dotnet.Models;

namespace mototrack_backend_rest_dotnet.Data.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly ApplicationContext _context;

    public ColaboradorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<PageResultModel<IEnumerable<ColaboradorEntity>>> ObterTodosColaboradoresAsync(int deslocamento = 0, int registrosRetornados = 10)
    {
        var totalRegistros = await _context.Colaborador.CountAsync();

        var result = await _context
            .Colaborador
            .OrderBy(c => c.Id)
            .Skip(deslocamento)
            .Take(registrosRetornados)
            .ToListAsync();

        return new PageResultModel<IEnumerable<ColaboradorEntity>>
        {
            Data = result,
            Deslocamento = deslocamento,
            RegistrosRetornados = registrosRetornados,
            TotalRegistros = totalRegistros
        };
    }

    public async Task<ColaboradorEntity?> ObterColaboradorPorIdAsync(long id)
    {
        var result = await _context
            .Colaborador
            .FirstOrDefaultAsync(c => c.Id == id);

        return result;
    }

    public async Task<ColaboradorEntity?> AdicionarColaboradorAsync(ColaboradorEntity colaborador)
    {
        _context.Colaborador.Add(colaborador);
        await _context.SaveChangesAsync();

        return colaborador;
    }

    public async Task<ColaboradorEntity?> EditarColaboradorAsync(long id, ColaboradorEntity novoColaborador)
    {
        var colaboradorExistente = await _context.Colaborador.FirstOrDefaultAsync(c => c.Id == id);

        if (colaboradorExistente is null)
            return null;

        colaboradorExistente.Nome = novoColaborador.Nome;
        colaboradorExistente.Matricula = novoColaborador.Matricula;
        colaboradorExistente.Email = novoColaborador.Email;

        await _context.SaveChangesAsync();
        return colaboradorExistente;
    }

    public async Task<ColaboradorEntity?> DeletarColaboradorAsync(long id)
    {
        var colaborador = await _context.Colaborador.FindAsync(id);

        if (colaborador is null)
            return null;

        _context.Colaborador.Remove(colaborador);
        await _context.SaveChangesAsync();
        return colaborador;
    }
}

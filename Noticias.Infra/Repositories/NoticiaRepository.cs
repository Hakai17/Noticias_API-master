using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Entities;
using Noticias.Domain.Repositories;
using Noticias.Infra.Contexts;

namespace Noticias.Infra.Repositories;

public class NoticiaRepository : INoticiaRepository
{
    private readonly NoticiaContext _context;

    public NoticiaRepository(NoticiaContext context)
    {
        _context = context;
    }

    public async Task<Noticia> Create(Noticia noticia)
    { 
        _context.Add(noticia);
        await _context.SaveChangesAsync();
        return noticia;
    }

    public async Task<Noticia> Update(Noticia noticia)
    {
        _context.Entry(noticia).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return noticia;
    }

    public async Task<Noticia?> ObterPorId(int id)
    {
        var noticia = await _context.Set<Noticia>()
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return noticia;
    }

    public async Task<List<Noticia?>> ObterTodos()
    {
        var allNoticias = await _context.Set<Noticia>()
            .AsNoTracking()
            .ToListAsync();

        return allNoticias;
    }

    public async Task<Noticia> Remover(int id)
    {
        var noticia = await ObterPorId(id);

        if (noticia != null)
        {
            _context.Remove(noticia);
            await _context.SaveChangesAsync();
        }

        return noticia;
    }
}
using Noticias.Domain.Entities;

namespace Noticias.Domain.Repositories;

public interface INoticiaRepository
{
    Task<Noticia> Create(Noticia noticia);
    Task<Noticia> Update(Noticia noticia);
    Task<Noticia?> ObterPorId(int id);
    Task<List<Noticia?>> ObterTodos();
    Task<Noticia> Remover(int id);
}
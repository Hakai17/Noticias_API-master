using Noticias.Application.DTOs;

namespace Noticias.Application.Interfaces;

public interface INoticiaService
{
    Task<NoticiaDto> Create(NoticiaDto dto);
    Task<NoticiaDto> Update(int id, UpdateNoticiaDto dto);
    Task<NoticiaDto> ObterPorId(int id);
    Task<List<NoticiaDto>> ObterTodos();
    Task Remove(int id);

}
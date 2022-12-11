using AutoMapper;
using Noticias.Application.DTOs;
using Noticias.Application.Interfaces;
using Noticias.Domain.Entities;
using Noticias.Domain.Repositories;

namespace Noticias.Application.Services;

public class NoticiaService : INoticiaService
{
    private readonly INoticiaRepository _repository;
    private readonly IMapper _mapper;

    public NoticiaService(INoticiaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<NoticiaDto> Create(NoticiaDto dto)
    {
        var noticia = _mapper.Map<Noticia>(dto);

        await _repository.Create(noticia);

        return _mapper.Map<NoticiaDto>(noticia);
    }

    public async Task<NoticiaDto> Update(int id, UpdateNoticiaDto dto)
    {
        var noticiaExistente = await _repository.ObterPorId(id);

        if (noticiaExistente == null)
        {
            throw new Exception("A noticia não existe");
        }

        var noticia = _mapper.Map<Noticia>(dto);

        var noticiaUpdated = await _repository.Update(noticia);

        return _mapper.Map<NoticiaDto>(noticiaUpdated);
    }

    public async Task<NoticiaDto> ObterPorId(int id)
    {
        var noticiaExistente = await _repository.ObterPorId(id);

        if (noticiaExistente == null)
        {
            throw new Exception("A noticia não existe");
        }

        return _mapper.Map<NoticiaDto>(noticiaExistente);
    }

    public async Task<List<NoticiaDto>> ObterTodos()
    {
        var allNoticias = await _repository.ObterTodos();
        
        if (allNoticias == null)
        {
            throw new Exception("Não existe noticias");
        }

        return _mapper.Map<List<NoticiaDto>>(allNoticias);
    }

    public async Task Remove(int id)
    {
        await _repository.Remover(id);
    }
}
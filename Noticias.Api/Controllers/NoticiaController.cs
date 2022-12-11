 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noticias.Application.DTOs;
using Noticias.Application.Interfaces;
using Noticias.Domain.Entities;

namespace Noticias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _service;

        public NoticiaController(INoticiaService service)
        {
            _service = service;
        }

        [HttpPost("/Cria-noticia")]
        public async Task<IActionResult> Create(NoticiaDto dto)
        {
            var noticia = await _service.Create(dto);

            return Ok(noticia);
        }

        [HttpGet("/obter-noticia/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var noticia = await _service.ObterPorId(id);

            return Ok(noticia);
        }

        [HttpGet("/obter-todas-noticias")]
        public async Task<OkObjectResult> GetAll()
        {
            var noticia = await _service.ObterTodos();

            return Ok(noticia);
        }

        [HttpPut("/atualizar-noticia/{id}")]
        public async Task<IActionResult> Update(int id, UpdateNoticiaDto dto)
        {
            var noticia = await _service.Update(id, dto);

            return Ok(noticia);
        }

        [HttpDelete("remover-noticia/{id}")]
        public async Task Delete(int id)
        {
            await _service.Remove(id);
        }
    }
}

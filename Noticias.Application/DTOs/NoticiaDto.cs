using System.ComponentModel.DataAnnotations;

namespace Noticias.Application.DTOs;

public class NoticiaDto
{
    [Required(ErrorMessage = "O titulo não pode ser vazio")]
    [MaxLength(120, ErrorMessage = "O titulo deve ter no máximo 120 caracteres")]
    [MinLength(5, ErrorMessage = "o titulo deve ter no mínimo 3 caracteres")]
    public string Titulo { get; set; } = null!;
    
    [Required(ErrorMessage = "O texto não pode ser vazio")]
    [MaxLength(5000, ErrorMessage = "O texto deve ter no máximo 5000 caracteres")]
    [MinLength(5, ErrorMessage = "O texto deve ter no mínimo 5 caracteres")]
    public string Texto { get; set; } = null!;
}
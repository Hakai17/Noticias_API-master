namespace Noticias.Domain.Entities;

public class Noticia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public DateTime DataDeCriacao { get; set; } = DateTime.Now;
}
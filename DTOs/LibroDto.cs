namespace GestionBibliotecaApi.DTOs;

public class LibroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Año { get; set; }
    public bool Disponible { get; set; } = true;

}

public class CrearLibroDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Año { get; set; }
    public bool Disponible { get; set; } = true;

}

public class ActualizarLibroDto
{
    public bool Disponible { get; set; } = true;

}
namespace GestionBibliotecaApi.Models;

using System.ComponentModel.DataAnnotations;

public class Libro
{
    public int Id {get; set;}
    public string Titulo {get; set;}= string.Empty;
    public string Autor {get; set;} = string.Empty;
    public int Año{get; set;}  
    public bool Disponible {get; set;} = true;
}
namespace GestionBibliotecaApi.Models;

using System.ComponentModel.DataAnnotations;

public class Miembro
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;

    [EmailAddress]
    public string Email {get; set;}= string.Empty;
    public DateTime FechaRegistro {get; set;}

}
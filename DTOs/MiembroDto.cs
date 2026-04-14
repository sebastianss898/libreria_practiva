namespace GestionBibliotecaApi.DTOs;

public class MiembroDto
{
    public int Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string Email {get; set;}= string.Empty;
    public DateTime FechaRegistro {get; set;}
}

public class CrearMiembroDto
{
    public string Nombre {get; set;} = string.Empty;
    public string Email {get; set;}= string.Empty;
    public DateTime FechaRegistro {get; set;}
}

public class ActualizarMiembroDto
{
    public string Nombre {get; set;} = string.Empty;
    public string Email {get; set;}= string.Empty;
    public DateTime FechaRegistro {get; set;}
}
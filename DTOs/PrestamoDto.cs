namespace GestionBibliotecaApi.DTOs;

public class PrestamoDto
{
    public int Id { get; set; }
    public string Libro { get; set; }= string.Empty;
    public string Miembro { get; set; }= string.Empty;
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
}

public class CrearPrestamoDto
{
    public int LibroId { get; set; }
    public int MiembroId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
}

public class ActualizarPrestamoDto
{
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
}
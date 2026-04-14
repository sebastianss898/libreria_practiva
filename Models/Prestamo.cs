namespace GestionBibliotecaApi.Models;

using System.ComponentModel.DataAnnotations;

public class Prestamo
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public Libro? Libro { get; set; }
    public Miembro? Miembro { get; set; }
    public int MiembroId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
}

/*Prestamo:

Id, LibroId, MiembroId, FechaPrestamo, FechaDevolucion*/
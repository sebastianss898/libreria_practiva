namespace GestionBibliotecaApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Service;

[ApiController]
[Route("/libros")]

public class LibroController : ControllerBase
{
    public readonly LibroService _service;

    public LibroController(LibroService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var libro = await _service.GetById(id);
        return libro is null ? NotFound() : Ok(libro);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearLibroDto dto)
    {
        var (success, error, libro) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/Habitaciones/{libro!.Id}", libro);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>  Actualizar(int id, ActualizarLibroDto dto)
    {
        var libro = await _service.Actualizar(id, dto);
        return libro is null ? NotFound() : Ok(libro);
    }
}
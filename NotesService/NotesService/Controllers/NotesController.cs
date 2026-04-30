using Microsoft.AspNetCore.Mvc;
using NotesService.Models;
using NotesService.Services.Interfaces;

[ApiController]
[Route("api/users/{userId}/notes")]
public class NotesController : ControllerBase
{
    private readonly INotesService _service;

    public NotesController(INotesService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll(int userId)
    {
        return Ok("hello");
    }

    [HttpGet("{noteId}")]
    public IActionResult GetById(int userId, int noteId)
    {
        return Ok("hello");
    }

    [HttpPost]
    public IActionResult Create(int userId, CreateNoteDto note)
    {
        return Ok("hello");
    }

    [HttpPut("{noteId}")]
    public IActionResult Update(int userId, int noteId, UpdateNoteDto dto)
    {
        return Ok("hello");
    }

    [HttpDelete("{noteId}")]
    public IActionResult Delete(int userId, int noteId)
    {
        return Ok("hello");
    }
}
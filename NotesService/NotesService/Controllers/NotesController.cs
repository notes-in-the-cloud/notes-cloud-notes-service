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
    public IActionResult GetAll(Guid userId)
    {
        return Ok("hello");
    }

    [HttpGet("{noteId}")]
    public IActionResult GetById(Guid userId, Guid noteId)
    {
        return Ok("hello");
    }

    [HttpPost]
    public IActionResult Create(Guid userId, Note note)
    {
        return Ok("hello");
    }

    [HttpPut("{noteId}")]
    public IActionResult Update(Guid userId, Guid noteId, UpdateNoteDto dto)
    {
        return Ok("hello");
    }

    [HttpDelete("{noteId}")]
    public IActionResult Delete(Guid userId, Guid noteId)
    {
        return Ok("hello");
    }
}
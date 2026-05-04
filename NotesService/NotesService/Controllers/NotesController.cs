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
        var notes = _service.GetAll(userId);
        return Ok(notes);
    }

    [HttpGet("{noteId}")]
    public IActionResult GetById(Guid userId, Guid noteId)
    {
        var note = _service.GetById(userId, noteId);
        if(note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }

    [HttpPost]
    public IActionResult Create(Guid userId, NoteDto noteDto)
    {
        var note = _service.Create(userId, noteDto);
        return Created($"api/users/{userId}/notes/{note.Id}", note);
    }

    [HttpPut("{noteId}")]
    public IActionResult Update(Guid userId, Guid noteId, NoteDto noteDto)
    {
        var note = _service.Update(userId, noteId, noteDto);
        if (note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }

    [HttpDelete("{noteId}")]
    public IActionResult Delete(Guid userId, Guid noteId)
    {
        _service.Delete(userId, noteId);
        return NoContent();
    }
}
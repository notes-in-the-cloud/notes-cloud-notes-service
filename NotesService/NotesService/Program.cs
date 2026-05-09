using NotesService.Services.Classes;
using NotesService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<INotesService, NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapGet("/api/healthz", () => Results.Ok(new
{
    status = "UP",
    service = "notes-service"
}));

app.MapGet("/api/readyz", () => Results.Ok(new
{
    status = "READY",
    service = "notes-service"
}));

app.MapControllers();

app.Run();
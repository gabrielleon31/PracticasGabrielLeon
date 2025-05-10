using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlite("Data Source=todo.db"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/api/todos", (TodoContext db) =>
    db.Todos.ToList());

app.MapGet("/api/todos/{id}", (int id, TodoContext db) =>
{
    var t = db.Todos.Find(id);
    return t is not null ? Results.Ok(t) : Results.NotFound();
});

app.MapPost("/api/todos", (Todo todo, TodoContext db) =>
{
    db.Todos.Add(todo);
    db.SaveChanges();
    return Results.Created($"/api/todos/{todo.Id}", todo);
});

app.MapPut("/api/todos/{id}", (int id, Todo todo, TodoContext db) =>
{
    if (id != todo.Id) return Results.BadRequest();
    var t = db.Todos.Find(id);
    if (t is null) return Results.NotFound();
    t.Name = todo.Name;
    t.IsComplete = todo.IsComplete;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/api/todos/{id}", (int id, TodoContext db) =>
{
    var t = db.Todos.Find(id);
    if (t is null) return Results.NotFound();
    db.Todos.Remove(t);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();

class Todo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
}

class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    public DbSet<Todo> Todos { get; set; }
}

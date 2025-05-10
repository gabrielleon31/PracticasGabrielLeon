using Microsoft.EntityFrameworkCore;
using MiApi.Models;
using MiApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductoContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductoContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/productos", async (ProductoContext db) =>
    await db.Productos.ToListAsync());

app.MapGet("/api/productos/{id}", async (int id, ProductoContext db) =>
    await db.Productos.FindAsync(id) is Producto p ? Results.Ok(p) : Results.NotFound());

app.MapPost("/api/productos", async (Producto prod, ProductoContext db) =>
{
    db.Productos.Add(prod);
    await db.SaveChangesAsync();
    return Results.Created($"/api/productos/{prod.Id}", prod);
});

app.MapPut("/api/productos/{id}", async (int id, Producto prod, ProductoContext db) =>
{
    if (id != prod.Id) return Results.BadRequest();
    var existing = await db.Productos.FindAsync(id);
    if (existing is null) return Results.NotFound();
    existing.Nombre = prod.Nombre;
    existing.Precio = prod.Precio;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/productos/{id}", async (int id, ProductoContext db) =>
{
    var p = await db.Productos.FindAsync(id);
    if (p is null) return Results.NotFound();
    db.Productos.Remove(p);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

namespace MiApi.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}

namespace MiApi.Data
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }
        public DbSet<MiApi.Models.Producto> Productos { get; set; }
    }
}

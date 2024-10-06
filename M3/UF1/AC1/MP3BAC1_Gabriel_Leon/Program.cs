//PARTE 1
internal class Program
{
    private static void Main(string[] args)
{
        Proyecto proyecto = new Proyecto("Proyecto Web", "Desarrollo de una aplicación web", 90, 200);

        proyecto.Empleados.Add(new Empleado("Kevin Tejeda", "Desarrollador", 3000));
        proyecto.Empleados.Add(new Empleado("Sergi DiGoat", "Diseñador", 2800));

        proyecto.Tareas.Add(new Tarea("Diseño UX", "Pendiente", "Diseñar la experiencia de usuario"));
        proyecto.Tareas.Add(new Tarea("Desarrollo Frontend", "Pendiente", "Implementar la interfaz de usuario"));

        Console.WriteLine($"Proyecto: {proyecto.Nombre}");
        Console.WriteLine($"Descripción: {proyecto.Descripcion}");
        Console.WriteLine($"Días restantes: {proyecto.DiasRestantes}");

        Console.WriteLine("\nLista de empleados asignados al proyecto:");
        foreach (var empleado in proyecto.Empleados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}, Cargo: {empleado.Cargo}, Salario: ${empleado.Salario}");
        }

        Console.WriteLine("\nLista de tareas:");
        foreach (var tarea in proyecto.Tareas)
        {
            Console.WriteLine($"Nombre: {tarea.Nombre}, Estado: {tarea.Estado}, Descripción: {tarea.Descripcion}");
        }

        Console.WriteLine($"Costo estimado del proyecto: ${proyecto.CalcularCostoEstimadoTotal()}");
        Console.WriteLine($"Estado actual del proyecto: {proyecto.EstadoProyecto}");
        Console.WriteLine($"\nTareas pendientes: {proyecto.ContarTareasPendientes()}");
        Console.WriteLine($"Número de empleados: {proyecto.ContarEmpleados()}");
    }
}

public class Empleado
{
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string cargo, decimal salario)
    {
        Nombre = nombre;
        Cargo = cargo;
        Salario = salario;
    }
}

public class Tarea
{
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public string Descripcion { get; set; }

    public Tarea(string nombre, string estado, string descripcion)
    {
        Nombre = nombre;
        Estado = estado;
        Descripcion = descripcion;
    }
}

public class Proyecto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> Empleados { get; set; }
    public List<Tarea> Tareas { get; set; }
    public decimal CostoEstimadoPorDia { get; set; }
    public string EstadoProyecto { get; set; }

    public Proyecto(string nombre, string descripcion, int diasRestantes, decimal costoEstimadoPorDia)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        DiasRestantes = diasRestantes;
        CostoEstimadoPorDia = costoEstimadoPorDia;
        Empleados = new List<Empleado>();
        Tareas = new List<Tarea>();
        EstadoProyecto = "En Progreso"; 
    }

    public decimal CalcularCostoEstimadoTotal()
    {
        return DiasRestantes * CostoEstimadoPorDia;
    }

    public int ContarTareasPendientes()
    {
        return Tareas.Count(t => t.Estado == "Pendiente");
    }

    public int ContarEmpleados()
    {
        return Empleados.Count;
    }
}

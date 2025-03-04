public class Api<T> 
{
    private List<T> elementos;

    public Api()
    {
        elementos = new List<T>();
    }

    public void AgregarElemento(T elemento)
    {
        elementos.Add(elemento);
    }

    public void EliminarElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Indice fuera de rango");
        }
    }

    public T ObtenerElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            return elementos[indice];
        }
        else
        {
            Console.WriteLine("Indice fuera de rango");
            return default(T); 
        }
    }

    public void MostrarElementos()
    {
        foreach (var elemento in elementos)
        {
            Console.WriteLine(elemento.ToString());
        }
    }

    public void ActualizarElemento(int indice, T nuevoElemento)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos[indice] = nuevoElemento;
        }
        else
        {
            Console.WriteLine("Indice fuera de rango");
        }
    }

    public T BuscarElemento(Predicate<T> criterio)
    {
        return elementos.Find(criterio);
    }
}

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }

    public Producto(int id, string nombre, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio}";
    }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Cliente(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}";
    }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }

    public Empleado(int id, string nombre, string cargo)
    {
        Id = id;
        Nombre = nombre;
        Cargo = cargo;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Cargo: {Cargo}";
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var apiProductos = new Api<Producto>();
        var apiClientes = new Api<Cliente>();
        var apiEmpleados = new Api<Empleado>();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nElige una opcion");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Agregar Cliente");
            Console.WriteLine("3. Agregar Empleado");
            Console.WriteLine("4. Mostrar Productos");
            Console.WriteLine("5. Mostrar Clientes");
            Console.WriteLine("6. Mostrar Empleados");
            Console.WriteLine("7. Eliminar Producto");
            Console.WriteLine("8. Eliminar Cliente");
            Console.WriteLine("9. Eliminar Empleado");
            Console.WriteLine("10. Actualizar Producto");
            Console.WriteLine("11. Buscar Producto");
            Console.WriteLine("12. Salir");
            
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Pon el ID del Producto: ");
                    int productoId = int.Parse(Console.ReadLine());
                    Console.Write("Pon el nombre del Producto: ");
                    string productoNombre = Console.ReadLine();
                    Console.Write("Pon el precio del Producto: ");
                    decimal productoPrecio = decimal.Parse(Console.ReadLine());
                    apiProductos.AgregarElemento(new Producto(productoId, productoNombre, productoPrecio));
                    break;
                case "2":
                    Console.Write("Pon el ID del Cliente: ");
                    int clienteId = int.Parse(Console.ReadLine());
                    Console.Write("Pon el nombre del Cliente: ");
                    string clienteNombre = Console.ReadLine();
                    apiClientes.AgregarElemento(new Cliente(clienteId, clienteNombre));
                    break;
                case "3":
                    Console.Write("Pon el ID del Empleado: ");
                    int empleadoId = int.Parse(Console.ReadLine());
                    Console.Write("Pon el nombre del Empleado: ");
                    string empleadoNombre = Console.ReadLine();
                    Console.Write("Pon el cargo del Empleado: ");
                    string empleadoCargo = Console.ReadLine();
                    apiEmpleados.AgregarElemento(new Empleado(empleadoId, empleadoNombre, empleadoCargo));
                    break;
                case "4":
                    Console.WriteLine("Productos:");
                    apiProductos.MostrarElementos();
                    break;
                case "5":
                    Console.WriteLine("Clientes:");
                    apiClientes.MostrarElementos();
                    break;
                case "6":
                    Console.WriteLine("Empleados:");
                    apiEmpleados.MostrarElementos();
                    break;
                case "7":
                    Console.Write("Pon el indice del Producto a eliminar: ");
                    int productoIndice = int.Parse(Console.ReadLine());
                    apiProductos.EliminarElemento(productoIndice);
                    break;
                case "8":
                    Console.Write("Pon el indice del Cliente a eliminar: ");
                    int clienteIndice = int.Parse(Console.ReadLine());
                    apiClientes.EliminarElemento(clienteIndice);
                    break;
                case "9":
                    Console.Write("Pon el indice del Empleado a eliminar: ");
                    int empleadoIndice = int.Parse(Console.ReadLine());
                    apiEmpleados.EliminarElemento(empleadoIndice);
                    break;
                case "10":
                    Console.Write("Pon el indice del Producto a actualizar: ");
                    int productoIndiceActualizar = int.Parse(Console.ReadLine());
                    Console.Write("Pon el nuevo nombre del Producto: ");
                    string nuevoNombreProducto = Console.ReadLine();
                    Console.Write("Pon el nuevo precio del Producto: ");
                    decimal nuevoPrecioProducto = decimal.Parse(Console.ReadLine());
                    apiProductos.ActualizarElemento(productoIndiceActualizar, new Producto(productoIndiceActualizar, nuevoNombreProducto, nuevoPrecioProducto));
                    break;
                case "11":
                    Console.Write("Pon el nombre del Producto a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    var productoEncontrado = apiProductos.BuscarElemento(p => p.Nombre.Contains(nombreBuscar));
                    Console.WriteLine(productoEncontrado != null ? $"Producto encontrado: {productoEncontrado}" : "Producto no encontrado");
                    break;
                case "12":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Error, elige de nuevo");
                    break;
            }
        }
    }
}
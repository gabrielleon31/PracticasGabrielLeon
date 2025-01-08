public class Videojuego
{
    public string Titulo { get; set; }
    public int AñoLanzamiento { get; set; }
    public string Tematica { get; set; }
    public string EstudioDesarrollo { get; set; }
    public int VecesAlquilado { get; set; }

    public Videojuego(string titulo, int añoLanzamiento, string tematica, string estudioDesarrollo)
    {
        Titulo = titulo;
        AñoLanzamiento = añoLanzamiento;
        Tematica = tematica;
        EstudioDesarrollo = estudioDesarrollo;
        VecesAlquilado = 0;
    }

    public void Alquilar()
    {
        VecesAlquilado++;
    }

    public override string ToString()
    {
        return $"Titulo: {Titulo}, Año: {AñoLanzamiento}, Tematica: {Tematica}, Estudio: {EstudioDesarrollo}, Veces Alquilado: {VecesAlquilado}";
    }
}

public class Cliente
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public LinkedList<Videojuego> JuegosAlquilados { get; set; }

    public Cliente(string nombre, string apellido, int edad, string direccion, string telefono)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Telefono = telefono;
        JuegosAlquilados = new LinkedList<Videojuego>();
    }

    public void AlquilarJuego(Videojuego juego)
    {
        JuegosAlquilados.AddLast(juego);
        juego.Alquilar();
    }

    public void MostrarJuegosAlquilados()
    {
        Console.WriteLine($"{Nombre} {Apellido} tiene los siguientes juegos alquilados:");
        foreach (var juego in JuegosAlquilados)
        {
            Console.WriteLine($"- {juego.Titulo}");
        }
    }
}

public class Empleado : Cliente
{
    public string Categoria { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string apellido, int edad, string direccion, string telefono, string categoria, decimal salario)
        : base(nombre, apellido, edad, direccion, telefono)
    {
        Categoria = categoria;
        Salario = salario;
    }

    public override string ToString()
    {
        return base.ToString() + $", Categoria: {Categoria}, Salario: {Salario}";
    }
}

public class SistemaAlquiler
{
    public LinkedList<Videojuego> videojuegosDisponibles;
    public LinkedList<Cliente> clientes;
    public LinkedList<Empleado> empleados;

    public SistemaAlquiler()
    {
        videojuegosDisponibles = new LinkedList<Videojuego>();
        clientes = new LinkedList<Cliente>();
        empleados = new LinkedList<Empleado>();
    }

    public void AltaCliente(Cliente cliente)
    {
        clientes.AddLast(cliente);
    }

    public void BajaCliente(Cliente cliente)
    {
        var clienteBaja = clientes.FirstOrDefault(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido);

        if (clienteBaja != null)
        {
            clientes.Remove(clienteBaja);
            Console.WriteLine($"Cliente {clienteBaja.Nombre} {clienteBaja.Apellido} ha sido dado de baja");
        }
        else
        {
            Console.WriteLine("El cliente no existe");
        }
    }

    public void AltaEmpleado(Empleado empleado)
    {
        empleados.AddLast(empleado);
    }

    public void BajaEmpleado(Empleado empleado)
    {
        var empleadoBaja = empleados.FirstOrDefault(e => e.Nombre == empleado.Nombre && e.Apellido == empleado.Apellido);

        if (empleadoBaja != null)
        {
            empleados.Remove(empleadoBaja);
            Console.WriteLine($"Empleado {empleadoBaja.Nombre} {empleadoBaja.Apellido} ha sido dado de baja");
        }
        else
        {
            Console.WriteLine("El empleado no existe");
        }
    }

    public void AltaVideojuego(Videojuego videojuego)
    {
        videojuegosDisponibles.AddLast(videojuego);
    }

    public void BajaVideojuego(Videojuego videojuego)
    {
        var videojuegoBaja = videojuegosDisponibles.FirstOrDefault(v => v.Titulo == videojuego.Titulo);

        if (videojuegoBaja != null)
        {
            videojuegosDisponibles.Remove(videojuegoBaja);
            Console.WriteLine($"Videojuego {videojuegoBaja.Titulo} ha sido dado de baja");
        }
        else
        {
            Console.WriteLine("El videojuego no existe");
        }
    }

    public void ListarVideojuegosDisponibles()
    {
        Console.WriteLine("Videojuegos disponibles:");
        foreach (var videojuego in videojuegosDisponibles)
        {
            Console.WriteLine(videojuego.ToString());
        }
    }

    public void ListarVideojuegosAlquilados()
    {
        Console.WriteLine("Videojuegos alquilados:");
        foreach (var videojuego in videojuegosDisponibles)
        {
            if (videojuego.VecesAlquilado > 0)
            {
                Console.WriteLine(videojuego.ToString());
            }
        }
    }

    public void ListarVideojuegosPorUsuario(Cliente cliente)
    {
        var clienteExistente = clientes.FirstOrDefault(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido);

        if (clienteExistente != null)
        {
            clienteExistente.MostrarJuegosAlquilados();
        }
        else
        {
            Console.WriteLine("El cliente no existe");
        }
    }

    public void ListarUsuariosConJuegosPrestados()
    {
        Console.WriteLine("Usuarios con juegos prestados:");
        foreach (var cliente in clientes)
        {
            if (cliente.JuegosAlquilados.Count > 0)
            {
                Console.WriteLine($"{cliente.Nombre} {cliente.Apellido}");
            }
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        SistemaAlquiler sistema = new SistemaAlquiler();

        while (true)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Alta de cliente");
            Console.WriteLine("2. Baja de cliente");
            Console.WriteLine("3. Alta de empleado");
            Console.WriteLine("4. Baja de empleado");
            Console.WriteLine("5. Alta de videojuego");
            Console.WriteLine("6. Baja de videojuego");
            Console.WriteLine("7. Alquilar videojuego");
            Console.WriteLine("8. Listar videojuegos disponibles");
            Console.WriteLine("9. Listar videojuegos alquilados");
            Console.WriteLine("10. Listar videojuegos por usuario");
            Console.WriteLine("11. Listar usuarios con juegos prestados");
            Console.WriteLine("0. Salir");

            int opcion = 0;
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Te equivocaste, intentalo again :)");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("\nAñade un cliente:");
                        Console.Write("Nombre: ");
                        string nombreCliente = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellidoCliente = Console.ReadLine();
                        Console.Write("Edad: ");
                        int edadCliente = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Direccion: ");
                        string direccionCliente = Console.ReadLine();
                        Console.Write("Telefono: ");
                        string telefonoCliente = Console.ReadLine();
                        Cliente cliente = new Cliente(nombreCliente, apellidoCliente, edadCliente, direccionCliente, telefonoCliente);
                        sistema.AltaCliente(cliente);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error, escribe bien porfa :)");
                    }
                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("\nEscribe el nombre y apellido del cliente para dar de baja:");
                        string[] nombreApellidoBaja = Console.ReadLine().Split(' ');

                        if (nombreApellidoBaja.Length == 2)
                        {
                            string nombreBaja = nombreApellidoBaja[0];
                            string apellidoBaja = nombreApellidoBaja[1];

                            var clienteBaja = new Cliente(nombreBaja, apellidoBaja, 0, "", "");
                            sistema.BajaCliente(clienteBaja);
                        }
                        else
                        {
                            Console.WriteLine("Error, escribe el nombre y apellido separado :)");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error al intentar dar de baja el cliente: " + e.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("\nAñade un empleado:");
                        Console.Write("Nombre: ");
                        string nombreEmpleado = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellidoEmpleado = Console.ReadLine();
                        Console.Write("Edad: ");
                        int edadEmpleado = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Direccion: ");
                        string direccionEmpleado = Console.ReadLine();
                        Console.Write("Telefono: ");
                        string telefonoEmpleado = Console.ReadLine();
                        Console.Write("Categoria: ");
                        string categoriaEmpleado = Console.ReadLine();
                        Console.Write("Salario: ");
                        decimal salarioEmpleado = Convert.ToDecimal(Console.ReadLine());
                        Empleado empleado = new Empleado(nombreEmpleado, apellidoEmpleado, edadEmpleado, direccionEmpleado, telefonoEmpleado, categoriaEmpleado, salarioEmpleado);
                        sistema.AltaEmpleado(empleado);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error, escribe bien porfa :)");
                    }
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("\nEscribe el nombre y apellido del empleado para dar de baja:");
                        string[] nombreApellidoEmpleadoBaja = Console.ReadLine().Split(' ');

                        if (nombreApellidoEmpleadoBaja.Length == 2)
                        {
                            string nombreEmpleadoBaja = nombreApellidoEmpleadoBaja[0];
                            string apellidoEmpleadoBaja = nombreApellidoEmpleadoBaja[1];

                            var empleadoBaja = new Empleado(nombreEmpleadoBaja, apellidoEmpleadoBaja, 0, "", "", "", 0);
                            sistema.BajaEmpleado(empleadoBaja);
                        }
                        else
                        {
                            Console.WriteLine("Error, escribe el nombre y apellido separado :)");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error al intentar dar de baja el empleado: " + e.Message);
                    }
                    break;

                case 5:
                    try
                    {
                        Console.WriteLine("\nAñade un videojuego:");
                        Console.Write("Titulo: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Año de lanzamiento: ");
                        int añoLanzamiento = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Tematica: ");
                        string tematica = Console.ReadLine();
                        Console.Write("Estudio de desarrollo: ");
                        string estudioDesarrollo = Console.ReadLine();
                        Videojuego videojuego = new Videojuego(titulo, añoLanzamiento, tematica, estudioDesarrollo);
                        sistema.AltaVideojuego(videojuego);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error, escribe bien porfa :)");
                    }
                    break;

                case 6:
                    Console.WriteLine("\nEscribe el titulo del videojuego para dar de baja:");
                    string tituloBaja = Console.ReadLine();
                    var videojuegoBaja = new Videojuego(tituloBaja, 0, "", "");
                    sistema.BajaVideojuego(videojuegoBaja);
                    break;

                case 7:
                    try
                    {
                        Console.WriteLine("\nSelecciona un cliente para alquilar un videojuego:");
                        Console.WriteLine("Clientes disponibles:");
                        int i = 1;
                        foreach (var cliente in sistema.clientes)
                        {
                            Console.WriteLine($"{i}. {cliente.Nombre} {cliente.Apellido}");
                            i++;
                        }

                        int clienteSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1;
                        var clienteAlquilar = sistema.clientes.ElementAt(clienteSeleccionado);

                        Console.WriteLine("\nSelecciona un videojuego para alquilar:");
                        Console.WriteLine("Videojuegos disponibles:");
                        int j = 1;
                        foreach (var videojuego in sistema.videojuegosDisponibles)
                        {
                            Console.WriteLine($"{j}. {videojuego.Titulo}");
                            j++;
                        }

                        int videojuegoSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1;
                        var videojuegoAlquilar = sistema.videojuegosDisponibles.ElementAt(videojuegoSeleccionado);

                        clienteAlquilar.AlquilarJuego(videojuegoAlquilar);
                        Console.WriteLine($"El cliente {clienteAlquilar.Nombre} {clienteAlquilar.Apellido} ha alquilado el videojuego {videojuegoAlquilar.Titulo}.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error al intentar alquilar el videojuego: " + e.Message);
                    }
                    break;

                case 8:
                    sistema.ListarVideojuegosDisponibles();
                    break;

                case 9:
                    sistema.ListarVideojuegosAlquilados();
                    break;

                case 10:
                    Console.WriteLine("\nEscribe el nombre del cliente para listar sus juegos alquilados:");
                    string nombreUsuario = Console.ReadLine();
                    Console.WriteLine("Escribe el apellido del cliente:");
                    string apellidoUsuario = Console.ReadLine();

                    var usuario = new Cliente(nombreUsuario, apellidoUsuario, 0, "", "");
                    sistema.ListarVideojuegosPorUsuario(usuario);
                    break;

                case 11:
                    sistema.ListarUsuariosConJuegosPrestados();
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Error, no pasa nada, intentalo again :)");
                    break;
            }
        }
    }
}


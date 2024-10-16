public abstract class Robot
{
    public string Nombre { get; set; }
    public string TipoUnidad { get; set; }
    public int NivelBateria { get; set; }

    protected Robot(string nombre, string tipoUnidad, int nivelBateria)
    {
        Nombre = nombre;
        TipoUnidad = tipoUnidad;
        NivelBateria = nivelBateria;
    }
}

public class DroideProtocolo : Robot
{
    public DroideProtocolo(string nombre, int nivelBateria)
        : base(nombre, "Protocolo", nivelBateria)
    {
    }
}

public class DroideAstromecánico : Robot
{
    public DateTime UltimaReparacion { get; set; }

    public DroideAstromecánico(string nombre, int nivelBateria, DateTime ultimaReparacion)
        : base(nombre, "Astromecanico", nivelBateria)
    {
        UltimaReparacion = ultimaReparacion;
    }

    public int NavesReparadas()
    {
        return new Random().Next(1, 101); 
    }
}

public class DroideCombate : Robot
{
    public int NivelPotenciaFuego { get; set; }

    public DroideCombate(string nombre, int nivelBateria, int nivelPotenciaFuego)
        : base(nombre, "Combate", nivelBateria)
    {
        NivelPotenciaFuego = nivelPotenciaFuego;
    }

    public int CombatesParticipados()
    {
        return new Random().Next(1, 51); 
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Robot> robots = new List<Robot>();
        robots.Add(new DroideProtocolo("C3PO", 85));
        robots.Add(new DroideAstromecánico("R2D2", 90, DateTime.Now.AddDays(-30)));
        robots.Add(new DroideCombate("Droideka", 70, 200));

        Console.WriteLine("Robots de Protocolo:");
        foreach (var robot in robots.OfType<DroideProtocolo>())
        {
            Console.WriteLine($"{robot.Nombre} - Bateria: {robot.NivelBateria}%");
        }

        Console.WriteLine("\nRobots Astromecanicos:");
        foreach (var robot in robots.OfType<DroideAstromecánico>())
        {
            Console.WriteLine($"{robot.Nombre} - Ultima reparacion: {robot.UltimaReparacion.ToShortDateString()} - Naves Reparadas: {robot.NavesReparadas()}");
        }

        Console.WriteLine("\nRobots de Combate:");
        foreach (var robot in robots.OfType<DroideCombate>())
        {
            Console.WriteLine($"{robot.Nombre} - Potencia de Fuego: {robot.NivelPotenciaFuego} - Combates: {robot.CombatesParticipados()}");
        }
    }
}

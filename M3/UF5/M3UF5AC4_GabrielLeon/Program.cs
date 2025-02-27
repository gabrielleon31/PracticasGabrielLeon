using System.Collections.Generic;
using System.Linq;

internal class Program
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
    }
    private static void Main(string[] args)
    {
        List<Persona> personas = new List<Persona>
        {
            new Persona("Juan", 30),
            new Persona("Pedro", 31),
            new Persona("Miguel", 25),
            new Persona("Luís", 36),
            new Persona("José", 25),
        };

        // Tarea 1: Encuentra el nombre de la persona más joven en la lista personas.
        var youngestPerson = (from person in personas
                              orderby person.Edad ascending
                              select person.Nombre).FirstOrDefault();
        Console.WriteLine("La persona mas joven es: " + youngestPerson);

        Console.WriteLine("\n--------\n");

        // Tarea 2: Calcula la edad promedio de todas las personas en la lista personas.
        var averageAge = (from person in personas
                          select person.Edad).Average();
        Console.WriteLine("La edad promedio es: " + averageAge);

        Console.WriteLine("\n--------\n");

        // Tarea 3: Encuentra todas las personas mayores de 25 años en la lista personas y ordénalas
        // alfabéticamente por nombre.
        var olderThan25 = from person in personas
                          where person.Edad > 25
                          orderby person.Nombre
                          select person;
        Console.WriteLine("Personas mayores de 25 años:");
        foreach (var person in olderThan25)
        {
            Console.WriteLine(person.Nombre);
        }

        Console.WriteLine("\n--------\n");

        // Tarea 4: Encuentra todas las personas cuyo nombre comienza con la letra "M" en la lista personas y
        // ordénalas por edad de forma descendente.
        var namesStartingWithM = from person in personas
                                 where person.Nombre.StartsWith("M")
                                 orderby person.Edad descending
                                 select person;
        Console.WriteLine("Personas que empiezan con 'M':");
        foreach (var person in namesStartingWithM)
        {
            Console.WriteLine(person.Nombre);
        }

        Console.WriteLine("\n--------\n");

        // Tarea 5: Verifica si todas las personas en la lista personas son mayores de 18 años.
        bool allAbove18 = personas.All(person => person.Edad > 18);
        Console.WriteLine("Todos son mayores de 18 años?: " + allAbove18);

        Console.WriteLine("\n--------\n");

        // Tarea 6: Encuentra la persona más joven en la lista personas que tenga un nombre que contenga la letra "a".
        var youngestWithA = (from person in personas
                             where person.Nombre.Contains("a")
                             orderby person.Edad ascending
                             select person.Nombre).FirstOrDefault();
        Console.WriteLine("La persona mas joven con una 'a' en su nombre es: " + youngestWithA);

        Console.WriteLine("\n--------\n");

        // Tarea 7: Agrupa las personas en la lista personas por su primera letra de nombre y muestra cuántas
        // personas hay en cada grupo.
        var groupedByFirstLetter = from person in personas
                                   group person by person.Nombre[0] into personGroup
                                   select new { Letter = personGroup.Key, Count = personGroup.Count() };
        Console.WriteLine("Agrupadas por la primera letra del nombre:");
        foreach (var group in groupedByFirstLetter)
        {
            Console.WriteLine($"Letra: {group.Letter}, Cantidad: {group.Count}");
        }

        Console.WriteLine("\n--------\n");

        // Usando Expresiones Lambda 

        // Tarea 8: Encuentra el nombre de la persona más joven que tenga una edad impar en la lista personas.
        var youngestOddAge = personas.Where(p => p.Edad % 2 != 0)
                                     .OrderBy(p => p.Edad)
                                     .FirstOrDefault();
        Console.WriteLine("La persona mas joven con una edad impar es: " + youngestOddAge?.Nombre);

        Console.WriteLine("\n--------\n");

        // Tarea 9: Elimina a todas las personas cuyas edades sean múltiplos de 5 de la lista personas y muestra la
        // lista resultante.

        var remainingPeople = personas.Where(p => p.Edad % 5 != 0).ToList();
        Console.WriteLine("Personas que su edad no es multiplo de 5:");
        foreach (var person in remainingPeople)
        {
            Console.WriteLine(person.Nombre);
        }

        Console.WriteLine("\n--------\n");

        // Tarea 10: Calcula la diferencia de edad entre la persona más joven y la persona más vieja en la lista
        // personas
        var minAge = personas.Min(p => p.Edad);
        var maxAge = personas.Max(p => p.Edad);
        var ageDifference = maxAge - minAge;
        Console.WriteLine("La diferencia de edad entre la persona mas joven y la mas vieja es: " + ageDifference);
    }
}
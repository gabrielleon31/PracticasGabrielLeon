using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string texto = "Los correos electrónicos son una forma común de comunicación en la era digital. Un correo" +
        "electrónico consta de varias partes, como el remitente, el destinatario, el asunto y el cuerpo" +
        "del mensaje. Algunos ejemplos de direcciones de correo electrónico son:" +
        "usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210." +
        "En el ámbito de la programación, las expresiones regulares son útiles para validar y buscar" +
        "patrones en direcciones de correo electrónico." +
        "Las expresiones regulares se pueden utilizar en muchos lenguajes de programación," +
        "incluyendo Python, JavaScript y Java.";

        Console.WriteLine("palabras que contienen la letra 'e':\n");
        var regex = new Regex(@"\b\w*e\w*\b", RegexOptions.IgnoreCase);
        var palabrasConE = regex.Matches(texto);
        foreach (var palabra in palabrasConE)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("palabras que finalizan con 'dad':\n");
        regex = new Regex(@"\b\w*dad\b", RegexOptions.IgnoreCase);
        var palabrasConDad = regex.Matches(texto);
        foreach (var palabra in palabrasConDad)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("apariciones de la palabra 'lenguajes':\n");
        regex = new Regex(@"\blenguajes\b", RegexOptions.IgnoreCase);
        var aparicionesLenguajes = regex.Matches(texto);
        foreach (var palabra in aparicionesLenguajes)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("palabras que inician con 's' y finalizan con 'n':\n");
        regex = new Regex(@"\bs\w*n\b", RegexOptions.IgnoreCase);
        var palabrasSN = regex.Matches(texto);
        foreach (var palabra in palabrasSN)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("numeros de telefono de 10 digitos:\n");
        regex = new Regex(@"\b\d{10}\b");
        var numerosTelefono = regex.Matches(texto);
        foreach (var numero in numerosTelefono)
        {
            Console.WriteLine(numero);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("correos electronicos con dominio '.es':\n");
        regex = new Regex(@"\b[A-Za-z0-9._%+-]+@[\w.-]+\.es\b");
        var correosES = regex.Matches(texto);
        foreach (var correo in correosES)
        {
            Console.WriteLine(correo);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("palabras que inician con 'a' y tienen 5 o mas caracteres:\n");
        regex = new Regex(@"\ba\w{4,}\b", RegexOptions.IgnoreCase);
        var palabrasA5 = regex.Matches(texto);
        foreach (var palabra in palabrasA5)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("palabras que son solo letras minusculas:\n");
        regex = new Regex(@"\b[a-z]+\b");
        var palabrasMinusculas = regex.Matches(texto);
        foreach (var palabra in palabrasMinusculas)
        {
            Console.WriteLine(palabra);
        }

        Console.WriteLine("\n--------\n");

        Console.WriteLine("sustitucion de 'Python' por 'C#':\n");
        string textoModificado = texto.Replace("Python", "C#");
        Console.WriteLine(textoModificado);
    }
}
// Escribe un programa en C# que solicite al usuario ingresar dos números y realice la división entre ellos. 
// Maneja una excepción cuando el usuario introduce valores no numéricos.

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//        try {

//         Console.WriteLine("Escribe un numero: ");
//         int a = Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Escribe otro numero: ");
//         int b = Convert.ToInt32(Console.ReadLine());

//         int c = a / b;

//         Console.WriteLine($"El resultado de la division es: {c}");

//        }

//        catch (FormatException e) {

//         Console.WriteLine($"Tienes este error: {e.Message}");

//        }
//     }
// }

// Escribe un programa en C# que implemente un método que reciba un número entero como entrada y lance una excepción 
// si el número es negativo. Maneja la excepción en el código que llama al método.

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//        try {

//         Console.WriteLine("Escribe un numero: ");
//         NumeroValido();

//        }

//         catch (ArgumentException e)
//         {
//             Console.WriteLine($"Tienes este error: {e.Message}");
//         }
//     }

//     private static int NumeroValido () {

//         int a = Convert.ToInt32(Console.ReadLine());

//         if (a < 0) {

//             throw new ArgumentException("El numero tiene que ser positivo");

//         }

//         return a;
//     }
// }

// Escribe un programa en C# que lea una ruta de archivo proporcionada por el usuario e intente abrir el archivo. 
// Maneja excepciones si el archivo no existe.

// internal class Program {

//     public static void Main(string[] args) {

//         try {

//         string path = "archivo.txt";

//         string contenido = File.ReadAllText(path);
//         Console.WriteLine("Contenido del archivo:\n" + contenido);

//         }

//         catch (FileNotFoundException ex) {

//             Console.WriteLine($"Error: El archivo no existe. Tienes este error: {ex.Message}");
//         }
//     }
// }

// Escribe un programa en C# que solicite al usuario ingresar un número entero.
// Lanza una excepción si el número es menor que 0 o mayor que 1000.

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//        try {

//         Console.WriteLine("Escribe un numero: ");
//         NumeroValido();

//        }

//         catch (ArgumentException e)
//         {
//             Console.WriteLine($"Tienes este error: {e.Message}");
//         }
//     }

//     private static int NumeroValido () {

//         int a = Convert.ToInt32(Console.ReadLine());

//         if (a < 0 || a > 1000) {

//             throw new ArgumentException("El numero tiene que ser mayor que 0 o menor que 1000");

//         }

//         return a;
//     }
// }

// Escribe un programa en C# que implemente un método que reciba un arreglo de enteros como entrada y calcule el valor promedio. 
// Maneja la excepción si el índice está fuera de rango
internal class  Program {

    public static void Main(string[] args) {

        try {
            
            int[] numeros = { 1, 2, 3, 4, 5 };
            int promedio = ArregloEnteros(numeros);
            Console.WriteLine($"Este es el promedio: {promedio}");
        }

        catch (IndexOutOfRangeException  ex) {

            Console.WriteLine($"Tienes este error {ex.Message}");

        }
    }

    private static int ArregloEnteros (int[] arr) {

    int suma = 0;

    for (int i = 0; i <= arr.Length; i++) //Con el "<=" se fuerza a la excepcion
    {
        suma += arr[i];
    }
        
            return suma / arr.Length;
            
    } 
}
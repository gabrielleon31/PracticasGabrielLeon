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

// internal class  Program {

//     public static void Main(string[] args) {

//         try {
            
//             int[] numeros = { 1, 2, 3, 4, 5 };
//             int promedio = ArregloEnteros(numeros);
//             Console.WriteLine($"Este es el promedio: {promedio}");
//         }

//         catch (IndexOutOfRangeException  ex) {

//             Console.WriteLine($"Tienes este error {ex.Message}");

//         }
//     }

//     private static int ArregloEnteros (int[] arr) {

//     int suma = 0;

//     for (int i = 0; i <= arr.Length; i++) //Con el "<=" se fuerza a la excepcion
//     {
//         suma += arr[i];
//     }
        
//             return suma / arr.Length;
            
//     } 
// }

// Escribe un programa que lea una cadena del usuario y la convierta en un entero. 
// Maneja la excepción si la entrada no se puede analizar como un entero.

// internal class  Program {

//     public static void Main(string[] args) {

//         try {
            
//             Console.WriteLine("Escribe una cadena: ");
//             string cadena = Console.ReadLine();
//             int cadenaNumerica = Convert.ToInt32(cadena);
//             Console.WriteLine("Cadena convertida: " + cadenaNumerica);
    
//         }

//         catch (FormatException ex) {

//             Console.WriteLine("Tienes este error:  " + ex.Message);
//         }
//     }
// }

// Escribe un programa que lea una lista de números enteros del usuario. 
// Maneja la excepción que ocurre si el usuario ingresa un valor fuera del rango de Int32.

// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         List<int> numeros = new List<int>();

//         Console.WriteLine("Escribe una lista de numeros: (escribe 'fin' para salir)");

//         while (true)
//         {
//             string entrada = Console.ReadLine();

//             if (entrada.ToLower() == "fin")
//                 break;

//             try
//             {
//                 int numero = Convert.ToInt32(entrada);
//                 numeros.Add(numero); 
//             }
//             catch (OverflowException ex)
//             {
//                 Console.WriteLine("Tienes este error: " + ex.Message);
//             }
//             catch (FormatException ex)
//             {
//                 Console.WriteLine("Tienes este error: " + ex.Message);
//             }
//         }
//     }
// }

// Escribe un programa que implemente un método que divida dos números. 
// Controla la excepción DivideByZeroException que se produce si el denominador es 0.

// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Escribe el numero que quieres dividir: ");
//         int num = Convert.ToInt32(Console.ReadLine());
//         int num2;

//         while (true)
//         {
//             try
//             {
//                 Console.WriteLine("Escribe el numero por el cual lo quieres dividir: ");
//                 num2 = Convert.ToInt32(Console.ReadLine());

//                 if (num2 == 0)
//                 {
//                     throw new DivideByZeroException("El denominador no puede ser 0");
//                 }

//                 int division = Dividir(num, num2);
//                 Console.WriteLine($"La division es: {division}");
//                 break;
//             }
//             catch (DivideByZeroException ex)
//             {
//                 Console.WriteLine("Tienes este error: " + ex.Message);
//             }
//         }
//     }

//     private static int Dividir(int num, int num2)
//     {
//         return num / num2;
//     }
// }

// Escribe un programa que lea un número del usuario y calcule su raíz cuadrada. 
// // Maneja la excepción si el número es negativo.

// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         while (true)
//         {
//             try
//             {
//                 Console.WriteLine("Escribe un numero: ");
//                 int num = Convert.ToInt32(Console.ReadLine());

//                 if (num < 0)
//                 {
//                     throw new ArgumentException("El numero debe ser positivo");
//                 }

//                 double resultado = Math.Sqrt(num);
//                 Console.WriteLine("Esta es su raiz cuadrada: " + resultado);
//                 break; 
//             }
//             catch (ArgumentException ex)
//             {
//                 Console.WriteLine("Tienes este error: " + ex.Message);
//             }
//         }
//     }
// }

// Escribe un programa que cree un método que tome una cadena como entrada y la convierta a mayúsculas. 
// Controla la excepción NullReferenceException que se produce si la cadena de entrada es nula.
// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         try
//         {
//             Console.WriteLine("Escribe una cadena: ");
//             string cadena = Console.ReadLine();

//             if (cadena == null)
//             {
//                 throw new NullReferenceException("La cadena no puede ser nula");
//             }

//             string cadenaMayusculas = ConvertirAMayusculas(cadena);
//             Console.WriteLine("Cadena en mayusculas: " + cadenaMayusculas);
//         }
//         catch (NullReferenceException ex)
//         {
//             Console.WriteLine("Tienes este error: " + ex.Message);
//         }
//     }

//     private static string ConvertirAMayusculas(string cadena)
//     {
//         return cadena.ToUpper();
//     }
// }

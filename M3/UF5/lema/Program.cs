using System;

namespace GenéricosEjemplo
{       public class ClaseGenerica<T> {
        public T Dato { get; set; }
        public ClaseGenerica(T dato)
        { Dato = dato; }    
        public void ImprimirDato()
        { Console.WriteLine("Dato: " + Dato); }
        public void MetodoGenerico<U>(U otroDato)
        { Console.WriteLine("Otro Dato: " + otroDato); } }
        ...public class Program {
        public static bool Compare<T>(T x, T y)
        { return x.Equals(y); }
        ...public static void Main(string[] args)
        { ClaseGenerica<int> objetoInt = new ClaseGenerica<int>(42);
          objetoInt.ImprimirDato();             // 42
          objetoInt.MetodoGenerico("Hola Mundo"); // Hola Mundo
            
          bool resultado1 = Compare<int>(10, 10);
          Console.WriteLine("10 es igual a 10? " + resultado1); } } }

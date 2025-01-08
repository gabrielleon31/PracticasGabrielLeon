// class Program {   
// private static void Main(string[] args) {
// Usuario usuario = new Usuario();
// UsuarioVIP usuarioVIP = new UsuarioVIP { Nombre = "Ana", NivelVIP = 2 };
// usuario.MensajeConsola();  
// usuarioVIP.MensajeConsola(); }}

// public class Usuario {
// public string Nombre { get; set; }
// public virtual void MensajeConsola () {
// Console.WriteLine("Holaaaa");}}

// public class UsuarioVIP : Usuario {
// public int NivelVIP { get; set; }
// public override void MensajeConsola(){
// Console.WriteLine($"El usuario {Nombre} tiene un nivel de {NivelVIP}");}}


//-------------------------------------------------------------------------------------

// public class Libro {
// public string Titulo {get; set; }
// public string Autor {get; set;}
// public Libro(string titulo, string autor) {
// Titulo = titulo;
// Autor = autor; }

// public void MostrarDatos () {
// Console.WriteLine($"Titulo: {Titulo}, Autor: {Autor}");}}

// class Program {
// public static void Main(string[] args) {
// Libro milibro = new Libro("LemamaLema", "Lema");
// milibro.MostrarDatos();}}

//------------------------------------------------------------------------------------

// public class Persona {

//     public string Nombre { get; set;}

//     public int Edad { get; set;}

//     //tendria que crear un constructor

//     public Persona (string nombre, int edad) {

//         Nombre = nombre;

//         Edad = edad;
//     }
// }

// class Program {

//     public static void Main(string[] args) {

//     Persona persona1 = new Persona("Lema", 30);

//     Console.WriteLine($"Nombre: {persona1.Nombre}, Edad: {persona1.Edad}");
//     }
// }

//------------------------------------------------------------------------------------------

// public class Persona

// {
//     protected string nombrePersona;   
//     public Persona(string nombre)
//     {
//         nombrePersona = nombre;
//     }

//     public void GetNombre(){

//         Console.WriteLine("el nombre de la persona es " + nombrePersona);

//     }
// }

// public class Jefe : Persona
// {
//     public string Departamento { get; set; }

//     public Jefe(string nombre, string departamento) : base(nombre)
//     {
//         Departamento = departamento;
//     }

//     public void GetDepartament() {

//         Console.WriteLine("el departamente es " + Departamento);
//     }
// }

// public class Empleado : Persona
// {
//     public string Salario { get; set; }

//     public Empleado(string nombre, string salario) : base(nombre)
//     {
//         Salario = salario;
//     }

//     public void GetSalario() {

//         Console.WriteLine("el departamente es " + Salario);
//     }
// }

// class Program {

//     static void Main(string[] args) {

//         Jefe jefe = new Jefe("Alice", "Desarrollo");
//         Empleado empleado = new Empleado("Bob", "50000");
//         Persona persona1 = new Persona("Lema");
//         // jefe.GetNombre(); 
//         // empleado.GetNombre(); 
//         // jefe.GetDepartament();
//         // empleado.GetSalario();
//         persona1.GetNombre();
//     }
// }

//-----------------------------

// class A  
// {  
//     public virtual void show()  
//     {  
//         Console.WriteLine("Hello: Base Class!");  
//         Console.ReadLine();  
//     }  
// }  
  

// class B : A  
// {  
//     public override void show()  
//     {  
//         Console.WriteLine("Hola!");  
//         Console.ReadLine();  
//     }  
// }

//-------------------------------------------------------------------------




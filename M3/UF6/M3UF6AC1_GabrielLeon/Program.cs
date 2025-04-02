using System.Data.SQLite;

namespace CRUD_Productos
{
    class Producto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }

    internal class Program
    {
        static string connectionString = "Data Source=productos.db;Version=3;";

        private static void Main(string[] args) 
        {
            CrearBaseDeDatosYTabla();

            int opcion = 0;
            do
            {
                MostrarMenu();
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Pon un numero valido");
                    continue;
                }

                switch(opcion)
                {
                    case 1:
                        CrearProducto();
                        break;
                    case 2:
                        ListarProductos();
                        break;
                    case 3:
                        BuscarProducto();
                        break;
                    case 4:
                        ActualizarProducto();
                        break;
                    case 5:
                        EliminarProducto();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Pon un numero entre 1 y 6 :)");
                        break;
                }
            } while (opcion != 6);
        }

        static void CrearBaseDeDatosYTabla()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Productos (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nombre TEXT NOT NULL,
                                Precio REAL NOT NULL,
                                Cantidad INTEGER NOT NULL
                              )";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n**Menú de Operaciones**");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Buscar Producto por Nombre");
            Console.WriteLine("4. Actualizar Producto");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("6. Salir");
            Console.Write("Que quieres hacer?: ");
        }

        static void CrearProducto()
        {
            Console.Write("Escribe el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Escribe el precio del producto: ");
            if (!double.TryParse(Console.ReadLine(), out double precio))
            {
                Console.WriteLine("Precio incorrecto");
                return;
            }

            Console.Write("Escribe la cantidad del producto: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                Console.WriteLine("Cantidad incorrecta");
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Productos (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                int result = command.ExecuteNonQuery();

                if(result > 0)
                    Console.WriteLine("Producto creado");
                else
                    Console.WriteLine("Error al crear el producto");
            }
        }

        static void ListarProductos()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Productos";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nLista de Productos:");
                while(reader.Read())
                {
                    Console.WriteLine("ID: {0} - Nombre: {1}, Precio: {2}, Cantidad: {3}",
                        reader["Id"], reader["Nombre"], reader["Precio"], reader["Cantidad"]);
                }
            }
        }

        static void BuscarProducto()
        {
            Console.Write("Escribe el nombre del producto que quieres buscar: ");
            string nombre = Console.ReadLine();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Productos WHERE Nombre LIKE @nombre";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                SQLiteDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nResultados de la busqueda:");
                bool encontrado = false;
                while(reader.Read())
                {
                    encontrado = true;
                    Console.WriteLine("ID: {0} - Nombre: {1}, Precio: {2}, Cantidad: {3}",
                        reader["Id"], reader["Nombre"], reader["Precio"], reader["Cantidad"]);
                }
                if(!encontrado)
                {
                    Console.WriteLine("No se encontraron productos con ese nombre");
                }
            }
        }

        static void ActualizarProducto()
        {
            Console.Write("Escribe el ID del producto que quieres actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Console.Write("Escribe el nuevo nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Escribe el nuevo precio del producto: ");
            if (!double.TryParse(Console.ReadLine(), out double precio))
            {
                Console.WriteLine("Precio incorrecto");
                return;
            }

            Console.Write("Escribe la nueva cantidad del producto: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                Console.WriteLine("Cantidad incorrecta");
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Productos SET Nombre = @nombre, Precio = @precio, Cantidad = @cantidad WHERE Id = @id";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@id", id);
                int result = command.ExecuteNonQuery();

                if(result > 0)
                    Console.WriteLine("Producto actualizado");
                else
                    Console.WriteLine("No se encontro el producto o no se pudo actualizar");
            }
        }

        static void EliminarProducto()
        {
            Console.Write("Escribe el ID del producto que quieres eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID incorrecto");
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Productos WHERE Id = @id";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                int result = command.ExecuteNonQuery();

                if(result > 0)
                    Console.WriteLine("Producto eliminado");
                else
                    Console.WriteLine("No se encontro el producto o no se pudo eliminar");
            }
        }
    }
}

using System.Text.Json;

namespace SlotMachineGame
{
    public static class MyRandom
    {
        public static Random Instance = new Random();
    }

    internal abstract class Robot
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Robot(int id, string modelo)
        {
            Id = id;
            Modelo = modelo;
            FechaCreacion = GenerateRandomDate();
        }

        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(MyRandom.Instance.Next(range));
        }

        public abstract void ShowData();
    }

    internal class R2D2 : Robot
    {
        public int Version { get; set; }

        public R2D2(int id) : base(id, "R2D2")
        {
            Version = MyRandom.Instance.Next(1, 10);
        }

        public int NumberOfBattles() => MyRandom.Instance.Next(1, 5);

        public override void ShowData()
        {
            Console.WriteLine($"R2D2 - ID: {Id}, Fecha: {FechaCreacion}, Version: {Version}, Batallas: {NumberOfBattles()}");
        }
    }

    internal class C3PO : Robot
    {
        public C3PO(int id) : base(id, "C3PO") { }

        public int NumberOfRepairs() => MyRandom.Instance.Next(1, 5);

        public override void ShowData()
        {
            Console.WriteLine($"C3PO - ID: {Id}, Fecha: {FechaCreacion}, Reparaciones: {NumberOfRepairs()}");
        }
    }

    internal class BB8 : Robot
    {
        public float Version { get; set; }

        public BB8(int id) : base(id, "BB8")
        {
            Version = (float)MyRandom.Instance.NextDouble();
        }

        public int NumberOfFlights() => MyRandom.Instance.Next(1, 5);
        public int NumberOfRepairs() => MyRandom.Instance.Next(1, 5);

        public override void ShowData()
        {
            Console.WriteLine($"BB8 - ID: {Id}, Fecha: {FechaCreacion}, Version: {Version}, Vuelos: {NumberOfFlights()}, Reparaciones: {NumberOfRepairs()}");
        }
    }

    internal class OrderManager<T>
    {
        private List<T> orders = new List<T>();

        public void AddOrder(T order) => orders.Add(order);
        public List<T> GetOrders() => orders;
        public int CalculateTotalPoints(Func<T, int> selector) => orders.Sum(selector);
        public int GetMaxPoints(Func<T, int> selector) => orders.Max(selector);
        public int GetMinPoints(Func<T, int> selector) => orders.Min(selector);
    }

    internal class SlotGame
    {
        private readonly int totalSpins = 10;
        private int totalBonusPoints = 0;
        private int robotIdCounter = 1;
        private OrderManager<Robot> orderManager = new OrderManager<Robot>();
        private const string SCORE_FILE = "resultados.txt";

        public void PlayGame()
        {
            for (int i = 0; i < totalSpins; i++)
            {
                Console.WriteLine("Dale a una tecla para jugar..");
                Console.ReadKey();
                MakeSpin();
            }
            EndGame();
        }

        private void MakeSpin()
        {
            List<int> resultados = GetRandomNumbersHttp();
            string simbolo1 = MapNumberToModel(resultados[0]);
            string simbolo2 = MapNumberToModel(resultados[1]);
            string simbolo3 = MapNumberToModel(resultados[2]);
            Console.WriteLine($"Resultado: [ {simbolo1} ] [ {simbolo2} ] [ {simbolo3} ]");

            int bonus = EvaluateBonus(resultados);
            totalBonusPoints += bonus;
            CreateRobots(resultados);
            Thread.Sleep(MyRandom.Instance.Next(500, 1500));
        }

        private void CreateRobots(List<int> resultados)
        {
            foreach (int num in resultados)
            {
                Robot robot = null;
                int id = robotIdCounter++;

                switch (num)
                {
                    case 1: robot = new R2D2(id); break;
                    case 2: robot = new C3PO(id); break;
                    case 3: robot = new BB8(id); break;
                    case 4: robot = new R2D2(id); break; 
                }

                if (robot != null)
                    orderManager.AddOrder(robot);
            }
        }

        private int EvaluateBonus(List<int> resultados)
        {
            if (resultados.Distinct().Count() == 1)
                return 10;
            else if (resultados.GroupBy(x => x).Any(g => g.Count() == 2))
                return 5;
            else
                return 0;
        }

        private void EndGame()
        {
            int puntosRobots = orderManager.GetOrders().Sum(r =>
            {
                if (r is R2D2) return 3;
                if (r is C3PO) return 2;
                if (r is BB8) return 1;
                return 0;
            });

            int puntuacionTotal = totalBonusPoints + puntosRobots;

            Console.WriteLine("Juego finalizado");
            Console.WriteLine($"Puntuacion total: {puntuacionTotal}");

            Console.Write("Escribe tu nombre: ");
            string userName = Console.ReadLine() ?? "Jugador";
            SaveScore(userName, puntuacionTotal);

            Console.WriteLine("Dale a una tecla para ver los robots generados..");
            Console.ReadKey();
            foreach (var robot in orderManager.GetOrders())
                robot.ShowData();

            ShowTop3Scores();
        }

        private void SaveScore(string userName, int puntuacionTotal)
        {
            string line = $"{userName};{puntuacionTotal};{DateTime.Now}";
            File.AppendAllText(SCORE_FILE, line + Environment.NewLine);
        }

        private void ShowTop3Scores()
        {
            Console.WriteLine("*Top 3 Puntuaciones*");
            if (!File.Exists(SCORE_FILE))
            {
                Console.WriteLine("No hay resultados previos");
                return;
            }

            var lines = File.ReadAllLines(SCORE_FILE);
            List<ScoreRecord> records = new List<ScoreRecord>();
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 3 &&
                    int.TryParse(parts[1], out int score) &&
                    DateTime.TryParse(parts[2], out DateTime fecha))
                {
                    records.Add(new ScoreRecord
                    {
                        UserName = parts[0],
                        Score = score,
                        Date = fecha
                    });
                }
            }

            var top3 = records.OrderByDescending(r => r.Score).Take(3);
            int rank = 1;
            foreach (var record in top3)
            {
                Console.WriteLine($"{rank}. {record.UserName} - {record.Score} puntos (Fecha: {record.Date})");
                rank++;
            }
        }

        private List<int> GetRandomNumbersHttp()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://www.randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3";
                try
                {
                    var response = client.GetAsync(url).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        List<int> numbers = JsonSerializer.Deserialize<List<int>>(json);
                        if (numbers != null && numbers.Count == 3)
                            return numbers;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Excepcion al llamar a la API: {ex.Message}");
                }
            }

            Console.WriteLine("Error en la comunicacion con la API: se usaran numeros aleatorios locales");
            return new List<int> { MyRandom.Instance.Next(1, 4), MyRandom.Instance.Next(1, 4), MyRandom.Instance.Next(1, 4) };
        }

        private string MapNumberToModel(int num)
        {
            return num switch
            {
                1 => "R2D2",
                2 => "C3PO",
                3 => "BB8",
                4 => "R2D2",
                _ => "Desconocido",
            };
        }
    }

    internal class ScoreRecord
    {
        public string UserName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            SlotGame game = new SlotGame();
            game.PlayGame();
        }
    }
}

namespace JuegoDeAventura
{
    public class Personaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Nivel { get; set; }
        public int PuntosHabilidad { get; set; }
        public int EnemigosDerrotados { get; set; }

        public Personaje(string nombre, int vida, int nivel)
        {
            Nombre = nombre;
            Vida = vida;
            Nivel = nivel;
            PuntosHabilidad = 0;
            EnemigosDerrotados = 0;
        }

        // Metodo para atacar (tirada de dos dados)
        public virtual int Atacar()
        {
            Random rand = new Random();
            int dado1 = rand.Next(1, 7); 
            int dado2 = rand.Next(1, 7); 
            int ataque = dado1 + dado2;

            // Asegura que el ataque no sea superior a 12
            if (ataque > 12) ataque = 12;

            return ataque;
        }

        // Metodo para defender (reduce la vida en funcion del daño recibido)
        public virtual void Defender(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0; // Evitar que la vida sea negativa
        }
    }

    public class Jugador : Personaje
    {
        public int GoblinsDerrotados { get; set; }
        public int DragonesDerrotados { get; set; }

        public Jugador(string nombre) : base(nombre, 10, 10) { }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} esta explorando y enfrentando enemigos.");
        }

        public virtual int AtacarJugador()
        {
            return Atacar();
        }

        public void AumentarPuntosHabilidad()
        {
            EnemigosDerrotados++;
            if (EnemigosDerrotados >= 2)
            {
                PuntosHabilidad++;
                Console.WriteLine($"{Nombre} ha ganado un punto de habilidad.");
                EnemigosDerrotados = 0; // Resetear el contador de enemigos derrotados
            }
        }

        public void SubirNivel()
        {
            Nivel++;
            Console.WriteLine($"{Nombre} ha subido de nivel. Ahora esta en el nivel {Nivel}.");
        }

        public bool PuedeEnfrentarGranJefe()
        {
            return GoblinsDerrotados >= 4 && DragonesDerrotados >= 1;
        }
    }

    public class Guerrero : Jugador
    {
        public Guerrero(string nombre) : base(nombre)
        {
            Vida = 12;
        }

        public override int AtacarJugador()
        {
            int ataque = base.Atacar();
            Console.WriteLine($"{Nombre} ataca con su espada.");
            return ataque + 2; // Guerrero tiene un bono de +2
        }
    }

    public class Mago : Jugador
    {
        public Mago(string nombre) : base(nombre)
        {
            Vida = 8;
        }

        public override int AtacarJugador()
        {
            int ataque = base.Atacar();
            Console.WriteLine($"{Nombre} lanza un hechizo!");
            return ataque + 4; // Mago tiene un bono de +4
        }
    }

    public class Arquero : Jugador
    {
        public Arquero(string nombre) : base(nombre)
        {
            Vida = 10;
        }

        public override int AtacarJugador()
        {
            int ataque = base.Atacar();
            Console.WriteLine($"{Nombre} dispara con su arco.");
            return ataque + 3; // Arquero tiene un bono de +3
        }
    }

    public class Enemigo : Personaje
    {
        public int NivelDeAtaque { get; set; }

        public Enemigo(string nombre) : base(nombre, new Random().Next(5, 13), new Random().Next(0, 16))
        {
            NivelDeAtaque = new Random().Next(1, 13); // Nivel de ataque aleatorio entre 1 y 12
        }

        public virtual int Atacar()
        {
            int ataque = base.Atacar() + NivelDeAtaque;
            if (ataque > 12) ataque = 12;
            return ataque;
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} se prepara para atacar al jugador.");
        }
    }

    public class EnemigoBasico : Enemigo
    {
        public EnemigoBasico(string nombre) : base(nombre) { }
    }

    public class EnemigoEspecial : Enemigo
    {
        public int Resistencia { get; set; }
        private int turnosDeResistencia;

        public EnemigoEspecial(string nombre) : base(nombre)
        {
            Resistencia = new Random().Next(0, 6);
            turnosDeResistencia = 0;
        }

        public override int Atacar()
        {
            int ataque = base.Atacar();
            return ataque - Resistencia;
        }

        public void ReducirResistencia()
        {
            if (Resistencia > 0)
            {
                Resistencia--;
                Console.WriteLine($"{Nombre}'s resistencia ha disminuido a {Resistencia}. Mas facil de derrotar ahora.");
            }
            else
            {
                Console.WriteLine($"{Nombre} ya no tiene resistencia.");
            }
        }
    }

    public class Boss : Enemigo
    {
        public int Resistencia { get; set; }
        private int turnosRegeneracion;

        public Boss(string nombre) : base(nombre)
        {
            Nivel = 20;
            Vida = 15;
            Resistencia = 5;
            turnosRegeneracion = 0;
        }

        // Metodo de ataque del Boss (posibilidad de ataque doble)
        public override int Atacar()
        {
            Random rand = new Random();
            int ataqueTotal = base.Atacar();
            if (rand.Next(0, 2) == 1)
            {
                ataqueTotal += base.Atacar();
            }
            return ataqueTotal;
        }

        public void RegenerarVida()
        {
            if (turnosRegeneracion == 3)
            {
                Vida += 2;
                Console.WriteLine($"{Nombre} ha recuperado 2 puntos de vida.");
                turnosRegeneracion = 0;
            }
            else
            {
                turnosRegeneracion++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el nombre del jugador:");
            string nombreJugador = Console.ReadLine();
            Jugador jugador = new Guerrero(nombreJugador);

            Enemigo enemigo = new EnemigoBasico("Goblin");

            int turno = 1;
            DateTime inicioJuego = DateTime.Now;  
            Random rand = new Random();

            while (jugador.Vida > 0)
            {
                Console.Clear();
                Console.WriteLine($"Turno {turno} - {jugador.Nombre} vs {enemigo.Nombre}");

                int ataqueJugador = jugador.AtacarJugador();
                Console.WriteLine($"{jugador.Nombre} ataca con {ataqueJugador} puntos.");
                enemigo.Defender(ataqueJugador);

                if (enemigo.Vida > 0)
                {
                    int ataqueEnemigo = enemigo.Atacar();
                    Console.WriteLine($"{enemigo.Nombre} ataca con {ataqueEnemigo} puntos.");
                    jugador.Defender(ataqueEnemigo);
                }

                if (enemigo.Vida <= 0)
                {
                    Console.WriteLine($"{enemigo.Nombre} ha sido derrotado.");
                    jugador.AumentarPuntosHabilidad();
                    if (enemigo is Boss)
                    {
                        Console.WriteLine("¡Felicidades! Has derrotado al Gran Jefe. ¡Has ganado el juego!");
                        break;
                    }
                    else
                    {
                        if (jugador.PuedeEnfrentarGranJefe())
                        {
                            enemigo = new Boss("Gran Jefe");
                        }
                        else
                        {
                            enemigo = GenerarEnemigo(rand);
                        }
                    }
                    jugador.SubirNivel();
                }

                MostrarEstado(jugador, enemigo);

                EventoSorpresa(rand, jugador);

                // Actualizar y mostrar el tiempo jugado
                TimeSpan tiempoJugado = DateTime.Now - inicioJuego;
                Console.WriteLine($"Tiempo jugado: {tiempoJugado.Minutes:D2}:{tiempoJugado.Seconds:D2}");

                turno++;
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
            }

            Console.WriteLine($"{jugador.Nombre} ha sido derrotado. ¡Fin del juego!");
            MostrarResumenFinal(jugador);
        }

        static void MostrarEstado(Jugador jugador, Enemigo enemigo)
        {
            Console.WriteLine($"\n--- Resumen de Turno ---");
            Console.WriteLine($"{jugador.Nombre}: Vida = {jugador.Vida}, Nivel = {jugador.Nivel}, Puntos de Habilidad = {jugador.PuntosHabilidad}");
            Console.WriteLine($"{enemigo.Nombre}: Vida = {enemigo.Vida}, Nivel = {enemigo.Nivel}");
            Console.WriteLine("------------------------");
        }

        static Enemigo GenerarEnemigo(Random rand)
        {
            Enemigo enemigo;
            int tipoEnemigo = rand.Next(0, 3);  
            switch (tipoEnemigo)
            {
                case 0:
                    enemigo = new EnemigoBasico("Goblin");
                    break;
                case 1:
                    enemigo = new EnemigoEspecial("Dragon");
                    break;
                case 2:
                    enemigo = new Boss("Gran Jefe");
                    break;
                default:
                    enemigo = new EnemigoBasico("Goblin");
                    break;
            }
            return enemigo;
        }

        static void EventoSorpresa(Random rand, Jugador jugador)
        {
            int evento = rand.Next(0, 3);  
            if (evento == 0)
            {
                Console.WriteLine("¡Has encontrado un cofre con una poción de vida!");
                jugador.Vida += 5;
            }
            else if (evento == 1)
            {
                Console.WriteLine("¡Cuidado! Has caído en una trampa.");
                jugador.Vida -= 5;
            }
        }

        static void MostrarResumenFinal(Jugador jugador)
        {
            Console.WriteLine("\n--- Resumen Final ---");
            Console.WriteLine($"Nivel Final: {jugador.Nivel}");
            Console.WriteLine($"Puntos de Habilidad: {jugador.PuntosHabilidad}");
        }
    }
}
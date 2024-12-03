using System;

namespace JuegoDeAventura
{
    // Clase base Personaje
    public class Personaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Nivel { get; set; }
        public int PuntosHabilidad { get; set; }
        public int TurnosEspecial { get; set; }
        public int EnemigosDerrotados { get; set; }

        public Personaje(string nombre, int vida, int nivel)
        {
            Nombre = nombre;
            Vida = vida;
            Nivel = nivel;
            PuntosHabilidad = 0;
            TurnosEspecial = 0;
            EnemigosDerrotados = 0;
        }

        // Método para atacar (tira de dados)
        public virtual int Atacar()
        {
            Random rand = new Random();
            return rand.Next(1, 7) + rand.Next(1, 7); // Tirada de dos dados de 6 caras
        }

        // Método para defenderse
        public virtual void Defender(int dano)
        {
            Vida -= dano;
            if (Vida < 0) Vida = 0;
        }

        // Método para ejecutar una misión
        public virtual void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} está realizando una misión de exploración.");
        }

        // Método para aumentar puntos de habilidad
        public void AumentarPuntosHabilidad()
        {
            EnemigosDerrotados++;
            if (EnemigosDerrotados >= 2)
            {
                PuntosHabilidad++;
                Console.WriteLine($"{Nombre} ha ganado un punto de habilidad.");
                EnemigosDerrotados = 0; // Resetear el contador
            }
        }
    }

    // Clase derivada Jugador
    public class Jugador : Personaje
    {
        public Jugador(string nombre) : base(nombre, 10, 10) { }  // Nivel inicial del jugador es 10

        public virtual void SubirNivel()
        {
            Nivel++;
            Console.WriteLine($"{Nombre} ha subido de nivel. Ahora está en el nivel {Nivel}.");
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} está explorando y enfrentando enemigos.");
        }
    }

    // Clases derivadas de Jugador (Guerrero, Mago, Arquero)
    public class Guerrero : Jugador
    {
        public Guerrero(string nombre) : base(nombre)
        {
            Vida = 12; // Guerreros tienen más vida
        }

        public void BloquearAtaque()
        {
            if (TurnosEspecial == 3)
            {
                Console.WriteLine($"{Nombre} ha bloqueado un ataque.");
                TurnosEspecial = 0; // Reseteamos el contador de turnos especiales
            }
            else
            {
                Console.WriteLine($"{Nombre} no puede bloquear el ataque aún. Debe esperar {3 - TurnosEspecial} turno(s) más.");
                TurnosEspecial++; // Incrementar el contador de turnos
            }
        }

        public override int Atacar()
        {
            int ataque = base.Atacar();
            double ataqueConHabilidad = ataque + (PuntosHabilidad * 0.10); // Se agregan los puntos de habilidad
            Console.WriteLine($"{Nombre} ataca con fuerza brutal.");
            return (int)ataqueConHabilidad + 2; // Guerrero tiene un bonus de ataque (+2)
        }
    }

    public class Mago : Jugador
    {
        public Mago(string nombre) : base(nombre)
        {
            Vida = 8; // Menos vida, pero más mágico
        }

        public void RecuperarVida()
        {
            if (TurnosEspecial == 3)
            {
                Vida += 2;
                Console.WriteLine($"{Nombre} ha recuperado 2 puntos de vida.");
                TurnosEspecial = 0; // Reseteamos el contador de turnos especiales
            }
            else
            {
                TurnosEspecial++;
            }
        }

        public override int Atacar()
        {
            int ataque = base.Atacar();
            double ataqueConHabilidad = ataque + (PuntosHabilidad * 0.10); // Se agregan los puntos de habilidad
            Console.WriteLine($"{Nombre} lanza un hechizo!");
            return (int)ataqueConHabilidad + 4; // Mago tiene un bonus de ataque (+4)
        }
    }

    public class Arquero : Jugador
    {
        public Arquero(string nombre) : base(nombre)
        {
            Vida = 10; // Menos vida que un Guerrero, pero mejor agilidad
        }

        // Habilidad especial: Doble tiro
        public void DobleTiro()
        {
            if (TurnosEspecial == 3)
            {
                Console.WriteLine($"{Nombre} realiza un doble tiro!");
                TurnosEspecial = 0; // Reseteamos el contador de turnos especiales
            }
            else
            {
                Console.WriteLine($"{Nombre} no puede realizar un doble tiro aún. Debe esperar {3 - TurnosEspecial} turno(s) más.");
                TurnosEspecial++; // Incrementar el contador de turnos
            }
        }

        public override int Atacar()
        {
            int ataque = base.Atacar();
            double ataqueConHabilidad = ataque + (PuntosHabilidad * 0.10); // Se agregan los puntos de habilidad
            Console.WriteLine($"{Nombre} dispara con su arco.");
            return (int)ataqueConHabilidad + 3; // Arquero tiene un bonus de ataque (+3)
        }
    }

    // Clases de Enemigos
    public class Enemigo : Personaje
    {
        public Enemigo(string nombre, int vida, int nivel) : base(nombre, vida, nivel) { }

        public virtual int Atacar()
        {
            return base.Atacar(); // Enemigos básicos tienen un ataque normal
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} se prepara para atacar al jugador.");
        }
    }

    public class EnemigoBasico : Enemigo
    {
        public EnemigoBasico(string nombre) : base(nombre, 5, 1) { }

        public override int Atacar()
        {
            return base.Atacar(); // Enemigos básicos tienen un ataque normal
        }
    }

    public class EnemigoEspecial : Enemigo
    {
        public int Resistencia { get; set; }

        public EnemigoEspecial(string nombre) : base(nombre, 8, 2)
        {
            Resistencia = new Random().Next(0, 6); // Resistencia aleatoria entre 0 y 5
        }

        public override int Atacar()
        {
            int ataque = base.Atacar();
            Console.WriteLine($"{Nombre} utiliza su resistencia especial.");
            return ataque - Resistencia; // La resistencia reduce el daño
        }
    }

    public class Boss : Enemigo
    {
        public int Resistencia { get; set; }

        public Boss(string nombre) : base(nombre, 15, 20)
        {
            Resistencia = 5; // El Boss tiene resistencia inicial de 5
        }

        public override int Atacar()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 1)
            {
                Console.WriteLine($"{Nombre} realiza un doble ataque.");
                return base.Atacar() + base.Atacar(); // Doble ataque
            }
            else
            {
                Console.WriteLine($"{Nombre} ataca normalmente.");
                return base.Atacar();
            }
        }

        public override void EjecutarMision()
        {
            Console.WriteLine($"{Nombre} está desatando su furia.");
        }
    }

    // Clase principal del programa
    class Programa
    {
        static void Main(string[] args)
        {
            Jugador jugador = new Arquero("Carlos Arquero");
            Enemigo enemigo = new EnemigoBasico("Goblin");
            Random rand = new Random();

            // Contador de turnos
            int turno = 1;
            DateTime inicioJuego = DateTime.Now;

            // Juego hasta que el jugador pierda o venza al boss
            while (jugador.Vida > 0 && turno <= 10) // Limitar a 10 turnos de juego por ejemplo
            {
                Console.WriteLine($"Turno {turno} - {jugador.Nombre} vs {enemigo.Nombre}");

                // Jugador ataca al enemigo
                int ataqueJugador = jugador.Atacar();
                Console.WriteLine($"{jugador.Nombre} atacó con {ataqueJugador} puntos.");

                // Enemigo ataca al jugador
                int ataqueEnemigo = enemigo.Atacar();
                Console.WriteLine($"{enemigo.Nombre} atacó con {ataqueEnemigo} puntos.");
                jugador.Defender(ataqueEnemigo);

                // Mostrar resultados de vida
                Console.WriteLine($"{jugador.Nombre} tiene {jugador.Vida} de vida.");

                // Misión
                jugador.EjecutarMision();
                enemigo.EjecutarMision();

                // Simular eventos de sorpresa (trampas, cofres)
                int eventoSorpresa = rand.Next(0, 3);
                if (eventoSorpresa == 0)
                    Console.WriteLine("¡Has encontrado un cofre con una poción de vida!");
                else if (eventoSorpresa == 1)
                    Console.WriteLine("¡Cuidado! Has caído en una trampa.");

                // Habilidad especial del Arquero (doble tiro)
                if (jugador is Arquero arquero)
                {
                    arquero.DobleTiro();
                }

                // Mostrar puntos de habilidad
                Console.WriteLine($"Puntos de habilidad: {jugador.PuntosHabilidad}");

                // Mostrar tiempo transcurrido en formato hh:mm
                TimeSpan tiempoJugado = DateTime.Now - inicioJuego;
                Console.WriteLine($"Tiempo jugado: {tiempoJugado.Hours:D2}:{tiempoJugado.Minutes:D2}");

                // Aumentar turno
                turno++;

                // Pausa para ver la información
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
            }

            // Fin del juego
            if (jugador.Vida <= 0)
                Console.WriteLine($"{jugador.Nombre} ha sido derrotado. ¡Fin del juego!");
            else
                Console.WriteLine($"{jugador.Nombre} ha ganado el juego. ¡Felicidades!");
        }
    }
}
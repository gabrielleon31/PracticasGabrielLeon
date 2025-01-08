namespace NavesEstelares
{
    class NaveEstelar
    {
        public string Nombre { get; set; }
        public int VelocidadMaxima { get; set; }

        public NaveEstelar(string nombre, int velocidadMaxima)
        {
            Nombre = nombre;
            VelocidadMaxima = velocidadMaxima;
        }

        public virtual void ActivarNave()
        {
            Console.WriteLine($"La {Nombre} ha activado sus sistemas.");
        }

        public virtual void EjecutarMision()
        {
            Console.WriteLine($"La {Nombre} está realizando una misión de exploración.");
        }

        public void ApagarNave()
        {
            Console.WriteLine($"La {Nombre} ha apagado sus sistemas.");
        }
    }

    class NaveDeCombate : NaveEstelar
    {
        public int PotenciaAtaque { get; set; }

        public NaveDeCombate(string nombre, int velocidadMaxima, int potenciaAtaque)
            : base(nombre, velocidadMaxima)
        {
            PotenciaAtaque = potenciaAtaque;
        }

        public override void ActivarNave()
        {
            Console.WriteLine($"La {Nombre} ha activado sus sistemas de combate.");
        }

        public override void EjecutarMision()
        {
            Console.WriteLine($"La {Nombre} está atacando con potencia de fuego nivel {PotenciaAtaque}.");
        }
    }

    class NaveDeCarga : NaveDeCombate
    {
        public int CapacidadCarga { get; set; }

        public NaveDeCarga(string nombre, int velocidadMaxima, int potenciaAtaque, int capacidadCarga)
            : base(nombre, velocidadMaxima, potenciaAtaque)
        {
            CapacidadCarga = capacidadCarga;
        }

        public override void ActivarNave()
        {
            Console.WriteLine($"La {Nombre} ha activado sus sistemas.");
        }

        public override void EjecutarMision()
        {
            Console.WriteLine($"La {Nombre} está atacando con potencia de fuego nivel {PotenciaAtaque}.");
            Console.WriteLine($"La {Nombre} está defendiendo el espacio alrededor del planeta X.");
        }

        public void MostrarCarga()
        {
            Console.WriteLine($"La nave de carga lleva una cantidad de carga de {CapacidadCarga} Kg.");
        }
    }

    internal class Programa
    {
        static void Main()
        {
            NaveEstelar nave1 = new NaveEstelar("nave estelar básica", 500);
            nave1.ActivarNave();
            nave1.EjecutarMision();
            nave1.ApagarNave();

            NaveDeCombate nave2 = new NaveDeCombate("nave de combate", 800, 7);
            nave2.ActivarNave();
            nave2.EjecutarMision();
            nave2.ApagarNave();

            NaveDeCarga nave3 = new NaveDeCarga("nave de carga", 400, 10, 2500);
            nave3.ActivarNave();
            nave3.EjecutarMision();
            nave3.MostrarCarga();
            nave3.ApagarNave();
        }
    }
}
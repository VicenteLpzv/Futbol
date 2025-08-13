using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SISTEMA DE LIGA DE FuTBOL \n");

        // 1) crear liga
        Liga laLiga = new Liga("la Liga", 2024);
        Console.WriteLine($"Liga creada: {laLiga.Nombre}");

        // 2) crear estadio (objeto real)
        Estadio campNou = new Estadio("Camp Nou", "Barcelona", 99354, 1957);

        // 3) crear equipos
        Equipo barcelona = new Equipo("FC Barcelona", "Barcelona");
        Equipo madrid = new Equipo("real Madrid", "Madrid");

        // 4) crear jugadores
        Jugador messi = new Jugador(10, "Lionel Messi", 36, "Delantero", 10, "Argentina");
        Jugador benzema = new Jugador(9, "Karim Benzema", 35, "Delantero", 9, "Francia");

        // 5) agregar jugadores a equipos
        barcelona.AgregarJugador(messi);
        madrid.AgregarJugador(benzema);

        // 6) agregar equipos a la liga
        laLiga.AgregarEquipo(barcelona);
        laLiga.AgregarEquipo(madrid);

        // 7) crear partido y registrarlo en la liga
        Partido clasico = new Partido(1, barcelona, madrid, DateTime.Now, campNou);
        laLiga.AgregarPartido(clasico);

        Console.WriteLine("\nINICIANDO EL PARTIDO");
        clasico.IniciarPartido();

        // 8) simular goles
        Console.WriteLine("Messi marca para el Barcelona!");
        clasico.RegistrarGol(true);
        messi.MarcarGol();

        Console.WriteLine("Benzema empata para el Madrid!");
        clasico.RegistrarGol(false);
        benzema.MarcarGol();

        // 9) Finalizar partido y actualizar tabla
        clasico.FinalizarPartido();
        Console.WriteLine($"\nResultado final: {clasico.GetResultado()}");

        // 10) Estadisticas basicas de jugadores
        Console.WriteLine("\nESTADÍSTICAS ");
        Console.WriteLine($"Goles de Messi: {messi.Goles}");
        Console.WriteLine($"Goles de Benzema: {benzema.Goles}");

        // 11) tabla de posiciones
        Console.WriteLine("\nTABLA DE POSICIONES");
        laLiga.MostrarTablaPosiciones();

        // 12) BONUS: Estadisticas avanzadas
        Console.WriteLine("\n BONUS: ESTADiSTICAS AVANZADAS");
        var stats = new EstadisticasLiga(laLiga);

        var pichichi = stats.GetMaxGoleador();
        Console.WriteLine($"maximo goleador: {pichichi?.Nombre} ({pichichi?.Goles})");

        var mejorAtaque = stats.GetMejorAtaque();
        Console.WriteLine($"mejor ataque: {mejorAtaque?.Nombre} (GF: {mejorAtaque?.GolesAFavor})");

        var mejorDefensa = stats.GetMejorDefensa();
        Console.WriteLine($"mejor defensa: {mejorDefensa?.Nombre} (GC: {mejorDefensa?.GolesEnContra})");

        var topPartidos = stats.GetPartidosConMasGoles(3);
        Console.WriteLine("partidos con mas goles:");
        foreach (var p in topPartidos)
        {
            Console.WriteLine($"  #{p.Id}: {p.EquipoLocal.Nombre} {p.GolesLocal} - {p.GolesVisitante} {p.EquipoVisitante.Nombre} (Total: {p.TotalGoles})");
        }

        Console.WriteLine($"promedio de goles por partido: {stats.GetPromedioGolesPorPartido():0.00}");

        var (lider, puntos) = stats.GetLiderActual();
        Console.WriteLine($"lider actual: {lider?.Nombre} ({puntos} pts)");

        Console.WriteLine("\nPresiona cualquier tecla para salir");
        Console.ReadKey();
    }
}


using System;

// estados del partido
public enum EstadoPartido { Programado, EnJuego, Finalizado }

// partido: referencia a equipos, estadio, goles y estado
public class Partido
{
    private int id;
    private DateTime fechaHora;
    private Estadio estadio;
    private EstadoPartido estado;

    private int golesLocal;
    private int golesVisitante;

    private readonly Equipo equipoLocal;
    private readonly Equipo equipoVisitante;

    public int Id => id;
    public EstadoPartido Estado => estado;

    public int GolesLocal => golesLocal;
    public int GolesVisitante => golesVisitante;
    public int TotalGoles => golesLocal + golesVisitante;

    public Equipo EquipoLocal => equipoLocal;
    public Equipo EquipoVisitante => equipoVisitante;
    public Estadio Estadio => estadio;

    // constructor con objeto Estadio
    public Partido(int id, Equipo local, Equipo visitante, DateTime fechaHora, Estadio estadio)
    {
        if (local == null) throw new ArgumentNullException(nameof(local));
        if (visitante == null) throw new ArgumentNullException(nameof(visitante));
        if (estadio == null) throw new ArgumentNullException(nameof(estadio));
        if (ReferenceEquals(local, visitante)) throw new ArgumentException("los equipos no pueden ser el mismo");

        this.id = id;
        this.equipoLocal = local;
        this.equipoVisitante = visitante;
        this.fechaHora = fechaHora;
        this.estadio = estadio;
        estado = EstadoPartido.Programado;
        golesLocal = 0;
        golesVisitante = 0;
    }

    // constructor alterno por compatibilidad con string de estadio
    public Partido(int id, Equipo local, Equipo visitante, DateTime fechaHora, string nombreEstadio)
        : this(id, local, visitante, fechaHora, new Estadio(nombreEstadio ?? "Sin estadio", "N/A", 0, DateTime.Now.Year))
    {
    }

    // pone el partido en juego
    public void IniciarPartido()
    {
        if (estado != EstadoPartido.Programado)
        {
            Console.WriteLine("el partido no puede iniciarse (no está Programado).");
            return;
        }
        estado = EstadoPartido.EnJuego;
        Console.WriteLine($"Partido #{Id} en {estadio.Nombre} — Comienza!");
    }

    // suma un gol al local o visitante si está en juego
    public void RegistrarGol(bool esLocal)
    {
        if (estado != EstadoPartido.EnJuego)
        {
            Console.WriteLine("No se pueden registrar goles: el partido no está en juego.");
            return;
        }
        if (esLocal) golesLocal++;
        else golesVisitante++;
    }

    // registra el resultado final de una sola vez (util para secuencia)
    public void RegistrarResultado(int gLocal, int gVisitante)
    {
        if (estado != EstadoPartido.EnJuego && estado != EstadoPartido.Programado)
        {
            Console.WriteLine("No se puede registrar resultado: el partido no está en juego ni programado.");
            return;
        }
        if (estado == EstadoPartido.Programado) estado = EstadoPartido.EnJuego; // permitir registrar al cierre
        golesLocal = Math.Max(0, gLocal);
        golesVisitante = Math.Max(0, gVisitante);
    }

    // finaliza el partido y actualiza estadísticas de los equipos
    public void FinalizarPartido()
    {
        if (estado != EstadoPartido.EnJuego)
        {
            Console.WriteLine("El partido no está en juego o ya finalizó");
            return;
        }
        estado = EstadoPartido.Finalizado;

        equipoLocal.ActualizarEstadisticasPartido(golesLocal, golesVisitante);
        equipoVisitante.ActualizarEstadisticasPartido(golesVisitante, golesLocal);

        Console.WriteLine("El partido ha finalizado.");
    }

    // Devuelve el marcador en texto
    public string GetResultado() => $"{equipoLocal.Nombre} {golesLocal} - {golesVisitante} {equipoVisitante.Nombre}";
}


using System;
using System.Collections.Generic;
using System.Linq;

// Equipo: gestiona plantilla y estadísticas de tabla.
public class Equipo
{
    private readonly List<Jugador> jugadores = new();
    private string nombre;
    private string ciudad;

    // Estadísticas
    private int puntos;
    private int golesAFavor;
    private int golesEnContra;
    private int partidosJugados;
    private int victorias;
    private int empates;
    private int derrotas;

    public string Nombre { get => nombre; set => nombre = string.IsNullOrWhiteSpace(value) ? "Sin nombre" : value; }
    public string Ciudad { get => ciudad; set => ciudad = string.IsNullOrWhiteSpace(value) ? "Sin ciudad" : value; }

    public int Puntos => puntos;
    public int DiferenciaDeGoles => golesAFavor - golesEnContra;
    public int GolesAFavor => golesAFavor;
    public int GolesEnContra => golesEnContra;
    public int PartidosJugados => partidosJugados;

    public IReadOnlyList<Jugador> Jugadores => jugadores;

    public Equipo(string nombre, string ciudad)
    {
        Nombre = nombre;
        Ciudad = ciudad;
    }

    // agrega un jugador si no existe
    public void AgregarJugador(Jugador j)
    {
        if (j == null) return;
        if (!jugadores.Contains(j)) jugadores.Add(j);
    }

    // remueve un jugador si existe
    public bool RemoverJugador(Jugador j)
    {
        if (j == null) return false;
        return jugadores.Remove(j);
    }

    // promedio de edades de la plantilla
    public double CalcularPromedioEdad() => jugadores.Count == 0 ? 0 : jugadores.Average(j => j.Edad);

    // plantilla en texto
    public string GetPlantilla() => jugadores.Count == 0 ? "(sin jugadores)" : string.Join(", ", jugadores.Select(j => j.Nombre));

    // ACtualiza tabla del equipo segun resultado
    public void ActualizarEstadisticasPartido(int golesFavor, int golesContra)
    {
        golesAFavor += golesFavor;
        golesEnContra += golesContra;
        partidosJugados++;

        if (golesFavor > golesContra) { victorias++; puntos += 3; }
        else if (golesFavor == golesContra) { empates++; puntos += 1; }
        else { derrotas++; }
    }
}

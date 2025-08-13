using System;
using System.Collections.Generic;
using System.Linq;

// calculos de estadísticas avanzadas sobre la liga
public class EstadisticasLiga
{
    private readonly Liga liga;

    public EstadisticasLiga(Liga liga)
    {
        this.liga = liga ?? throw new ArgumentNullException(nameof(liga));
    }

    // Jugador con más goles
    public Jugador GetMaxGoleador()
    {
        return liga.GetEquipos()
                   .SelectMany(e => e.Jugadores)
                   .OrderByDescending(j => j.Goles)
                   .FirstOrDefault();
    }

    // equipo con más goles a favor
    public Equipo GetMejorAtaque()
    {
        return liga.GetEquipos()
                   .OrderByDescending(e => e.GolesAFavor)
                   .FirstOrDefault();
    }

    // equipo con menos goles en contra
    public Equipo GetMejorDefensa()
    {
        return liga.GetEquipos()
                   .OrderBy(e => e.GolesEnContra)
                   .FirstOrDefault();
    }

    // partidos con mayor cantidad de goles (Top N)
    public List<Partido> GetPartidosConMasGoles(int top = 3)
    {
        return liga.GetPartidos()
                   .OrderByDescending(p => p.TotalGoles)
                   .ThenBy(p => p.Id)
                   .Take(top)
                   .ToList();
    }

    // promedio de goles por partido
    public double GetPromedioGolesPorPartido()
    {
        var ps = liga.GetPartidos();
        if (ps.Count == 0) return 0;
        return ps.Average(p => p.TotalGoles);
    }

    // equipo líder por puntos (desempate por DG)
    public (Equipo equipo, int puntos) GetLiderActual()
    {
        var lider = liga.GetEquipos()
                        .OrderByDescending(e => e.Puntos)
                        .ThenByDescending(e => e.DiferenciaDeGoles)
                        .FirstOrDefault();
        return (lider, lider?.Puntos ?? 0);
    }
}


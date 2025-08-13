using System;
using System.Collections.Generic;
using System.Linq;

// Liga: mantiene equipos, partidos y muestra tabla de posiciones
public class Liga
{
    private readonly List<Equipo> equipos = new();
    private readonly List<Partido> partidos = new();

    public string Nombre { get; private set; }
    public int Temporada { get; private set; }

    public Liga(string nombre, int temporada)
    {
        Nombre = string.IsNullOrWhiteSpace(nombre) ? "Sin nombre" : nombre;
        Temporada = temporada;
    }

    // agrega equipo si no existe
    public void AgregarEquipo(Equipo e)
    {
        if (e != null && !equipos.Contains(e))
            equipos.Add(e);
    }

    // agrega partido si no existe
    public void AgregarPartido(Partido p)
    {
        if (p != null && !partidos.Contains(p))
            partidos.Add(p);
    }

    // copias protegidas de colecciones
    public List<Equipo> GetEquipos() => equipos.ToList();
    public List<Partido> GetPartidos() => partidos.ToList();

    // muestra tabla de posiciones simple
    public void MostrarTablaPosiciones()
    {
        var tabla = equipos
            .OrderByDescending(e => e.Puntos)
            .ThenByDescending(e => e.DiferenciaDeGoles)
            .ThenBy(e => e.Nombre)
            .ToList();

        Console.WriteLine("Equipo".PadRight(22) + "Pts".PadLeft(4) + "  DG".PadLeft(5) + "  GF".PadLeft(5) + "  GC".PadLeft(5));
        Console.WriteLine(new string('-', 46));
        foreach (var e in tabla)
        {
            Console.WriteLine($"{e.Nombre.PadRight(22)}{e.Puntos,4}  {e.DiferenciaDeGoles,3}  {e.GolesAFavor,3}  {e.GolesEnContra,3}");
        }
    }
}


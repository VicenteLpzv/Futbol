using System;

// Estadio: datos del recinto donde se juega el partido
public class Estadio
{
    private string nombre;
    private string ciudad;
    private int capacidad;
    private int añoConstruccion;

    public string Nombre { get => nombre; set => nombre = string.IsNullOrWhiteSpace(value) ? "sin nombre" : value; }
    public string Ciudad { get => ciudad; set => ciudad = string.IsNullOrWhiteSpace(value) ? "sin ciudad" : value; }
    public int Capacidad { get => capacidad; set => capacidad = Math.Max(0, value); }
    public int AñoConstruccion { get => añoConstruccion; set => añoConstruccion = value < 1800 ? 1800 : value; }

    public Estadio(string nombre, string ciudad, int capacidad, int añoConstruccion)
    {
        Nombre = nombre;
        Ciudad = ciudad;
        Capacidad = capacidad;
        AñoConstruccion = añoConstruccion;
    }

    // nformación resumida del estadio
    public string MostrarInformacion() => $"{Nombre} ({Ciudad}) - Cap: {Capacidad}, Año: {AñoConstruccion}";

    // antigüedad en años
    public int CalcularAntiguedad() => DateTime.Now.Year - AñoConstruccion;

    // simula preparar la sede
    public void PrepararEstadio() => Console.WriteLine($"preparando {Nombre} para el encuentro..");
}

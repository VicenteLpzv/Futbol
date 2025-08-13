using System;

// Jugador: hereda de Persona. Maneja posición, número y goles
public class Jugador : Persona
{
    private string posicion;
    private int numeroCamiseta;
    private int goles;

    public string Posicion
    {
        get => posicion;
        set => posicion = string.IsNullOrWhiteSpace(value) ? "Sin posición" : value;
    }

    public int NumeroCamiseta
    {
        get => numeroCamiseta;
        set => numeroCamiseta = value < 0 ? 0 : value;
    }

    public int Goles
    {
        get => goles;
        private set => goles = Math.Max(0, value);
    }

    public Jugador(int id, string nombre, int edad, string posicion, int numeroCamiseta, string nacionalidad = "N/A")
        : base(id, nombre, edad, nacionalidad)
    {
        Posicion = posicion;
        NumeroCamiseta = numeroCamiseta;
        Goles = 0;
    }

    // suma un gol al jugador
    public void MarcarGol() => Goles++;

    // muestra una tarjeta recibida
    public void RecibirTarjeta(string tipoTarjeta)
        => Console.WriteLine($"Tarjeta {tipoTarjeta} para {Nombre} ({Posicion} #{NumeroCamiseta}).");

    // Cambiar posición
    public void CambiarPosicion(string nuevaPosicion) => Posicion = nuevaPosicion;

    // Cambiar numero
    public void AsignarNumero(int nuevoNumero) => NumeroCamiseta = nuevoNumero;

    public override string GetInfo()
        => $"Jugador: {Nombre} | #{NumeroCamiseta} | Pos: {Posicion} | Goles: {Goles}";

    //cálculo salarial
    public override decimal CalcularSalario() => 1000m + (Goles * 50m) + (Edad * 5m);
}

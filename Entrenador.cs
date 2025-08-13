using System;

// entrenador: hereda de Persona. tiene especialidad, experiencia, licencia y salario base
public class Entrenador : Persona
{
    private string especialidad;
    private int añosExperiencia;
    private string licencia;
    private decimal salarioBase;

    public string Especialidad { get => especialidad; set => especialidad = string.IsNullOrWhiteSpace(value) ? "general" : value; }
    public int AñosExperiencia { get => añosExperiencia; set => añosExperiencia = Math.Max(0, value); }
    public string Licencia { get => licencia; set => licencia = string.IsNullOrWhiteSpace(value) ? "No especificada" : value; }
    public decimal SalarioBase { get => salarioBase; set => salarioBase = value < 0 ? 0 : value; }

    public Entrenador(int id, string nombre, int edad, string especialidad, int añosExperiencia, string licencia, decimal salarioBase, string nacionalidad = "N/A")
        : base(id, nombre, edad, nacionalidad)
    {
        Especialidad = especialidad;
        AñosExperiencia = añosExperiencia;
        Licencia = licencia;
        SalarioBase = salarioBase;
    }

    // Acciones comunes del entrenador
    public void PlanificarPartido() => Console.WriteLine($"{Nombre} está planificando el partido");
    public void DirigirEntrenamiento() => Console.WriteLine($"{Nombre} dirige el entrenamiento");
    public void EvaluarJugadores() => Console.WriteLine($"{Nombre} evalúa el rendimiento de los jugadores");

    public override string GetInfo()
        => $"Entrenador: {Nombre} | Esp: {Especialidad} | Exp: {AñosExperiencia} años | Lic: {Licencia}";

    public override decimal CalcularSalario() => SalarioBase + (AñosExperiencia * 100m);
}


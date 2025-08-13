using System;

// clase base para personas (herencia/polimorfismo)
public abstract class Persona
{
    // campos privados
    private int id;
    private string nombre;
    private int edad;
    private string nacionalidad;

    // properties publicas (encapsulamiento)
    public int Id { get => id; set => id = value < 0 ? 0 : value; }
    public string Nombre { get => nombre; set => nombre = string.IsNullOrWhiteSpace(value) ? "Sin nombre" : value; }
    public int Edad { get => edad; set => edad = value < 0 ? 0 : value; }
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = string.IsNullOrWhiteSpace(value) ? "N/A" : value; }

    // constructor
    protected Persona(int id, string nombre, int edad, string nacionalidad = "N/A")
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Nacionalidad = nacionalidad;
    }

    // info basica de la persona
    public virtual string GetInfo() => $"{Nombre} (ID: {Id}, Edad: {Edad}, Nac: {Nacionalidad})";

    // debe ser implementado por las clases hijas
    public abstract decimal CalcularSalario();

    // validación simple de datos
    public virtual bool ValidarDatos() => Id >= 0 && !string.IsNullOrWhiteSpace(Nombre) && Edad >= 0;
}


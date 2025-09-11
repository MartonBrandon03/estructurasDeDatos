using System;
class Carro
{
    public string modelo { get; set; }
    public int año { get; set; }
    public Carro(string modelo, int año)
    {
        this.modelo = modelo;
        this.año = año;
    }
}
class datoAbstracto
{
    static void Main(string[] args)
    {
        Carro[] carros =
        {
            new Carro("Tida", 2015),
            new Carro("Versa", 2020),
            new Carro("Aveo", 2023)
        };
        foreach (Carro c in carros)
        {
            Console.WriteLine($"{c}({c.modelo}, {c.año})");
        }
        Console.WriteLine();
    }
}
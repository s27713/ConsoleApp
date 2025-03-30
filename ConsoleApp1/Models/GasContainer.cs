using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Models;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double maxLoad, double containerWeight, double height, double depth, double pressure)
        : base('G', maxLoad, containerWeight, height, depth)
    {
        Pressure = pressure;
    }

    public override void Load(double weight)
    {
        if (weight > MaxLoadWeight)
        {
            NotifyHazard(SerialNumber, $"Tried to load {weight}kg (limit: {MaxLoadWeight}kg)");
            throw new OverfillException("Overfill attempt detected in gas container.");
        }

        base.Load(weight);
    }

    public override void Unload()
    {
        LoadWeight *= 0.05;
    }

    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"[HAZARD - GAS] Container {containerNumber}: {message}");
    }

    public override string ToString()
    {
        return base.ToString() + $" | Pressure: {Pressure} atm";
    }
}
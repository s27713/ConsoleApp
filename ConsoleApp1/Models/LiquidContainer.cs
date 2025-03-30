using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Models;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(double maxLoad, double containerWeight, double height, double depth, bool isHazardous)
        : base('L', maxLoad, containerWeight, height, depth)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double allowedLoad = IsHazardous ? MaxLoadWeight * 0.5 : MaxLoadWeight * 0.9;

        if (weight > allowedLoad)
        {
            NotifyHazard(SerialNumber, $"Tried to load {weight}kg (limit: {allowedLoad}kg)");
            throw new OverfillException("Overfill attempt detected.");
        }

        base.Load(weight);
    }

    public void NotifyHazard(string containerNumber, string message)
    {
        Console.WriteLine($"[HAZARD] Container {containerNumber}: {message}");
    }
}
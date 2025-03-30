using ConsoleApp1.Exceptions;

namespace ConsoleApp1.Models;

public abstract class Container
{
    private static int _nextId = 1;

    public string SerialNumber { get; }
    public double LoadWeight { get; protected set; }
    public double MaxLoadWeight { get; }
    public double Height { get; }
    public double ContainerWeight { get; }
    public double Depth { get; }

    protected Container(char type, double maxLoadWeight, double containerWeight, double height, double depth)
    {
        SerialNumber = $"KON-{type}-{_nextId++}";
        MaxLoadWeight = maxLoadWeight;
        ContainerWeight = containerWeight;
        Height = height;
        Depth = depth;
        LoadWeight = 0;
    }

    public virtual void Load(double weight)
    {
        if (LoadWeight + weight > MaxLoadWeight)
            throw new OverfillException($"Container {SerialNumber} overloaded. Max: {MaxLoadWeight}, Tried: {weight}");
        LoadWeight += weight;
    }

    public virtual void Unload()
    {
        LoadWeight = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber} | Load: {LoadWeight} / {MaxLoadWeight} kg";
    }
}
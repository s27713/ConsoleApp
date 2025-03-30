namespace ConsoleApp1.Models;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeedKnots { get; }
    public int MaxContainerCount { get; }
    public double MaxTotalWeightTons { get; }

    private List<Container> _containers = new();

    public ContainerShip(string name, double maxSpeedKnots, int maxContainerCount, double maxTotalWeightTons)
    {
        Name = name;
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainerCount = maxContainerCount;
        MaxTotalWeightTons = maxTotalWeightTons;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainerCount)
            throw new Exception("Cannot load: container limit exceeded.");

        double currentWeight = _containers.Sum(c => c.LoadWeight + c.ContainerWeight);
        double newWeight = currentWeight + container.LoadWeight + container.ContainerWeight;

        if (newWeight > MaxTotalWeightTons * 1000)
            throw new Exception("Cannot load: total weight would exceed ship limit.");

        _containers.Add(container);
        Console.WriteLine($"[INFO] Container {container.SerialNumber} loaded onto ship {Name}");
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var c in containers)
            LoadContainer(c);
    }

    public void UnloadContainer(string serial)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null) throw new Exception("Container not found.");
        container.Unload();
        Console.WriteLine($"[INFO] Container {serial} has been unloaded.");
    }

    public void RemoveContainer(string serial)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null) throw new Exception("Container not found.");
        _containers.Remove(container);
        Console.WriteLine($"[INFO] Container {serial} removed from ship.");
    }

    public void ReplaceContainer(string serial, Container newContainer)
    {
        RemoveContainer(serial);
        LoadContainer(newContainer);
        Console.WriteLine($"[INFO] Container {serial} replaced with {newContainer.SerialNumber}");
    }

    public void TransferContainer(string serial, ContainerShip targetShip)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null) throw new Exception("Container not found.");

        RemoveContainer(serial);
        targetShip.LoadContainer(container);
        Console.WriteLine($"[INFO] Container {serial} transferred to {targetShip.Name}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"\n=== {Name} ===");
        Console.WriteLine($"Max Speed: {MaxSpeedKnots} knots");
        Console.WriteLine($"Max Containers: {MaxContainerCount}");
        Console.WriteLine($"Max Weight: {MaxTotalWeightTons} tons");
        Console.WriteLine($"Current Load: {_containers.Count} containers\n");

        foreach (var c in _containers)
        {
            Console.WriteLine(c);
        }
    }
}

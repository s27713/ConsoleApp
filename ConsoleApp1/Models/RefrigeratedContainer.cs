using ConsoleApp1.Exceptions;

namespace ConsoleApp1.Models;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double SetTemperature { get; }

    private static readonly Dictionary<string, double> ProductTemperatures = new()
    {
        {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish", 2}, {"Meat", -15},
        {"Ice cream", -18}, {"Frozen pizza", -30}, {"Cheese", 7.2},
        {"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };

    public RefrigeratedContainer(double maxLoad, double containerWeight, double height, double depth, string productType, double setTemperature)
        : base('C', maxLoad, containerWeight, height, depth)
    {
        ProductType = productType;
        SetTemperature = setTemperature;

        if (!ProductTemperatures.ContainsKey(productType))
            throw new ArgumentException("Unknown product type");

        double requiredTemp = ProductTemperatures[productType];

        if (setTemperature > requiredTemp)
            throw new ArgumentException($"Container temperature too high for {productType}. Required: {requiredTemp}°C");
    }

    public override void Load(double weight)
    {
        if (weight > MaxLoadWeight)
            throw new OverfillException("Too much load for refrigerated container.");
        base.Load(weight);
    }

    public override string ToString()
    {
        return base.ToString() + $" | Product: {ProductType} | Temp: {SetTemperature}°C";
    }
}
namespace ConsoleApp1.Interfaces;

public interface IHazardNotifier
{
    void NotifyHazard(string containerNumber, string message);
}
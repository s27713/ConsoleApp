using ConsoleApp1.Models;

var ship1 = new ContainerShip("Poseidon", 25, 100, 50000);
var ship2 = new ContainerShip("Neptune", 20, 50, 20000);

var liquid = new LiquidContainer(10000, 2000, 300, 400, true);
var gas = new GasContainer(5000, 1500, 200, 300, 10);
var fridge = new RefrigeratedContainer(3000, 1000, 200, 300, "Fish", 0);

liquid.Load(4000);
gas.Load(3000);
fridge.Load(2000);

ship1.LoadContainer(liquid);
ship1.LoadContainer(gas);
ship1.LoadContainer(fridge);

ship1.PrintInfo();

ship1.UnloadContainer(liquid.SerialNumber);
ship1.RemoveContainer(gas.SerialNumber);

var replacement = new RefrigeratedContainer(3500, 1000, 200, 300, "Meat", -18);
replacement.Load(2000);
ship1.ReplaceContainer(fridge.SerialNumber, replacement);

ship1.TransferContainer(replacement.SerialNumber, ship2);

ship1.PrintInfo();
ship2.PrintInfo();
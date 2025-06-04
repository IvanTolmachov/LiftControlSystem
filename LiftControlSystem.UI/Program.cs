using LiftControlSystem.Application;
using LiftControlSystem.Domain.Entities;

var liftController = new LiftController(10, new ClosestFirstStrategy());

// Simulate some button presses
Console.WriteLine("---------scenario 1-----------------------");
liftController.HandleFloorButton(FloorButtonType.Up, 0);
liftController.HandleLiftButton(5);

Console.WriteLine("---------scenario 2-----------------------");
liftController.HandleFloorButton(FloorButtonType.Down, 6);
liftController.HandleFloorButton(FloorButtonType.Down, 4);
liftController.HandleLiftButton(1);
liftController.HandleLiftButton(1);

Console.WriteLine("---------scenario 3-----------------------");
liftController.HandleFloorButton(FloorButtonType.Up, 2);
liftController.HandleFloorButton(FloorButtonType.Down, 4);
liftController.HandleLiftButton(6);
liftController.HandleLiftButton(0);

Console.WriteLine("--------scenario 4------------------------");
liftController.HandleFloorButton(FloorButtonType.Up, 0);
liftController.HandleLiftButton(5);
liftController.HandleFloorButton(FloorButtonType.Down, 4);
liftController.HandleFloorButton(FloorButtonType.Down, 10);
liftController.HandleLiftButton(0);
liftController.HandleLiftButton(0);

Console.WriteLine("-----------one more---------------------");
liftController.HandleFloorButton(FloorButtonType.Up, 2);
liftController.HandleFloorButton(FloorButtonType.Down, 5);
liftController.HandleLiftButton(3);
liftController.HandleLiftButton(0);

// Some edge cases to deal with later
//liftController.HandleLiftButton(11); // Should not do anything since it's out of range
//liftController.HandleFloorButton(FloorButtonType.Up, 10); // Should not do anything since it's the top floor
//liftController.HandleFloorButton(FloorButtonType.Down, 0); // Should not do anything since it's the ground floor
//liftController.HandleFloorButton(FloorButtonType.Down, 11); // Should not do anything since it's out of range
//liftController.HandleFloorButton(FloorButtonType.Up, -1); // Should not do anything since it's out of range
//liftController.HandleFloorButton(FloorButtonType.Down, -1); // Should not do anything since it's out of range
//liftController.HandleFloorButton(FloorButtonType.Down, 10); // Should not do anything since it's the top floor


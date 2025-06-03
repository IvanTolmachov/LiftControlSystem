namespace LiftControlSystem.Domain.Entities
{
    public class LiftCar(int currentFloor = 0, LiftCarState movement = LiftCarState.Idle)
    {
        public LiftCarState Movement { get; set; } = movement;
        public int CurrentFloor { get; set; } = currentFloor;
    }
}

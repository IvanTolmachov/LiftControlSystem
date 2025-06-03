namespace LiftControlSystem.Domain.Entities
{
    public enum LiftActionType
    {
        None = 0,
        GotoToFloor = 1,
        OpenDoorAtFloor = 2,
        CloseDoorAtFloor = 3,
        StopAtFloor = 4
    }
}

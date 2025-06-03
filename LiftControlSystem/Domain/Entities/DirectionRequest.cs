namespace LiftControlSystem.Domain.Entities
{
    public class DirectionRequest : IRequest
    {
        public FloorButtonType Direction { get; set; }
        public int Floor { get; set; }
    }
}

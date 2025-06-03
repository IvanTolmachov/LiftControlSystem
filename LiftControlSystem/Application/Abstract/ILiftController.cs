using LiftControlSystem.Domain.Entities;

namespace LiftControlSystem.Application.Abstract
{
    public interface ILiftController
    {
        void HandleFloorButton(FloorButtonType button, int floorAt);
        void HandleLiftButton(int floorTo);
    }
}

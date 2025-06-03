using LiftControlSystem.Domain.Entities;

namespace LiftControlSystem.Application.Abstract
{
    public interface ILiftOperationStrategy
    {
        IRequest ChooseNextJob(int currentFloor, ref List<IRequest> requestQueue);
    }
}

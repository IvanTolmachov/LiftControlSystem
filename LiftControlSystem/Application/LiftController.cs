using LiftControlSystem.Application.Abstract;
using LiftControlSystem.Domain.Entities;

namespace LiftControlSystem.Application
{
    public class LiftController : ILiftController
    {
        private readonly LiftCar _lift = new LiftCar();
        private readonly ILiftOperationStrategy _strategy;
        private List<IRequest> _requestQueue = [];
        private bool _isOnJob = false;

        public LiftController(int floorCount, ILiftOperationStrategy strategy)
        {
            _strategy = strategy;
            Console.WriteLine($"LiftController initialized with {floorCount} floors using strategy: {strategy.GetType().Name}");
            Console.WriteLine($"Lift is currently at floor {_lift.CurrentFloor}");
        }

        public void HandleFloorButton(FloorButtonType button, int floorAt)
        {
            // add validation for button at ground and top floors
            Console.WriteLine($"<-> {button} pressed at floor {floorAt}");
            var request = new DirectionRequest { Floor = floorAt, Direction = button };
            _requestQueue.Add(request);

            if (_isOnJob) {
                Console.WriteLine($"Lift is already on a job, so adding request to the queue but not yet processing");
            }
            else {
                _isOnJob = true;
                ProcessQueue();
            }
        }

        public void HandleLiftButton(int floorTo)
        {
            // add validation for floorTo within valid range and not the current floor
            Console.WriteLine($"<-> Lift button pressed to go to floor {floorTo}");
            var request = new DestinationRequest { Floor = floorTo };
            _requestQueue.Add(request);
            ProcessQueue();

            // If there are still requests in the queue, process them
            if (_requestQueue.Count > 0)
            {
                ProcessQueue();
            }
        }

        private void ProcessQueue()
        {
            if (_requestQueue.Count == 0)
            {
                Console.WriteLine("No requests to process");
                return;
            }
            var nextJob = _strategy.ChooseNextJob(_lift.CurrentFloor, ref _requestQueue);

            ProcessJob(nextJob);
        }

        private void ProcessJob(IRequest nextJob)
        {
            if (_lift.CurrentFloor == nextJob.Floor)
            {
                Console.WriteLine($"Opening doors at floor {_lift.CurrentFloor}.");
                _requestQueue.RemoveAll(r => r is DestinationRequest dr && dr.Floor == nextJob.Floor);
            }
            else
            {
                Console.WriteLine($"Closing doors at floor {_lift.CurrentFloor}, moving from floor {_lift.CurrentFloor} to floor {nextJob.Floor}, opening doors at floor {nextJob.Floor}");
                _lift.CurrentFloor = nextJob.Floor;
                _requestQueue.RemoveAll(r => r is DirectionRequest dr && dr.Floor == nextJob.Floor);
            }

            // If the next job is a DestinationRequest, we can mark job as completed
            if (nextJob is DestinationRequest destinationRequest)
            {
                _isOnJob = false;
            }
        }
    }
}

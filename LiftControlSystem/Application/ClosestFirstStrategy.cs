using LiftControlSystem.Application.Abstract;
using LiftControlSystem.Domain.Entities;

namespace LiftControlSystem.Application
{
    public class ClosestFirstStrategy : ILiftOperationStrategy
    {
        public IRequest ChooseNextJob(int currentFloor, ref List<IRequest> requestQueue)
        {
            // Implement the logic to choose the next floor based on the current floor and the request queue

            // If there are no requests in the priority queue, throw an exception
            if (requestQueue.Count == 0)
            {
                throw new InvalidOperationException("No requests available to process");
            }

            var priorityQueue = new PriorityQueue<IRequest, int>();

            // Add all destination requests to the priority queue based on their distance from the current floor
            // This will prioritize the closest floor requests first
            foreach (var request in requestQueue)
            {
                if (request is DestinationRequest destinationRequest)
                {
                    int distance = Math.Abs(destinationRequest.Floor - currentFloor);
                    priorityQueue.Enqueue(destinationRequest, distance);
                }
            }

            // If the destination priority queue is empty, we need to add direction requests based on their distance from the current floor
            if (priorityQueue.Count == 0)
            {
                foreach (var request in requestQueue)
                {
                    if (request is DirectionRequest directionRequest)
                    {
                        int distance = Math.Abs(directionRequest.Floor - currentFloor);
                        priorityQueue.Enqueue(directionRequest, distance);
                    }
                }
            }

            // If the priority queue is empty, throw an exception
            if (priorityQueue.Count == 0)
            {
                throw new InvalidOperationException("No valid requests available to process");
            }

            // Dequeue the request with the highest priority (closest floor)
            var nextRequest = priorityQueue.Dequeue();

            // Log the next request being processed
            Console.WriteLine($"Processing {nextRequest.GetType().Name} from floor {currentFloor} to floor {nextRequest.Floor}");

            // remove the processed request from the queue

            requestQueue.Remove(nextRequest);

            // Return the floor of the next request to process
            return nextRequest;


        }
    }
}

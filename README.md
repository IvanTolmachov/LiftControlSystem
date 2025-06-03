# LiftControlSystem

- Get latest to your local
- Set LiftControlSystem.UI as startup project in VS
- Run

There are a few test scenarios in Program.cs, including as per below 

The Challenge:

You are in charge of writing software for an elevator (lift) company.
Your task is to write a program to control the travel of a lift for a 10 storey building.
A passenger can summon the lift to go up or down from any floor, once in the lift they can choose the floor they'd like to travel to.
Your program needs to plan the optimal set of instructions for the lift to travel, stop, and open its doors.

Some test cases:
- Passenger summons lift on the ground floor. Once in, choose to go to level 5.
- Passenger summons lift on level 6 to go down. Passenger on level 4 summons the lift to go down. They both choose L1.
- Passenger 1 summons lift to go up from L2. Passenger 2 summons lift to go down from L4. Passenger 1 chooses to go to L6. Passenger 2 chooses to go to Ground Floor
- Passenger 1 summons lift to go up from Ground. They choose L5. Passenger 2 summons lift to go down from L4. Passenger 3 summons lift to go down from L10. Passengers 2 and 3 choose to travel to Ground.

Currently only one strategy is implemented (First In First Served) at a base level

TODO
- validation of inputs e.g. Floors within the range etc
- implementing optimized strategy e.g users can 'share' the lift when going the same direction etc

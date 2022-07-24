using ToyRobot;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayInstruction();
            var turtleSimulator = new ToyRobotSimulator(new ToyRobot());
            while (true)
            {
                string command = GetCommandFromUser();
                if (command.ToUpper().Equals("SHAZAM"))
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(turtleSimulator.ExecuteCommand(command));
            }
        }
        private static void DisplayInstruction()
        {
            Console.WriteLine("------------Turtle Simulator------------");
            Console.WriteLine("Please start by using PLACE command e.g PLACE 0,0,EAST");
            Console.WriteLine("Type SHAZAM to exit");
        }

        private static string GetCommandFromUser()
        {
            Console.WriteLine("Please Enter Command: ");
            return Console.ReadLine();
        }
    }
}
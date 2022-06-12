using System;

namespace RoboticInterface;

public class RoboticInterface
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public IRobotCommand[] Commands { get; } = new IRobotCommand[3];

        public Robot()
        {
            for (int i = 0; i < Commands.Length; i++)
            {
                string input = Console.ReadLine();
                this.Commands[i] = input switch
                {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "west" => new WestCommand(),
                    "east" => new EastCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                };
            }

            Console.WriteLine();
        }
        public void Run()
        {
            foreach (IRobotCommand command in Commands)
            {
                command.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }

    public interface IRobotCommand
    {
        void Run(Robot robot);
    }

    public class OnCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.IsPowered = true;
    }

    public class OffCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.IsPowered = false;
    }

    public class NorthCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.Y++;
    }

    public class SouthCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.Y--;
    }

    public class WestCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.X--;
    }

    public class EastCommand : IRobotCommand
    {
        public void Run(Robot robot) => robot.X++;
    }

    public static void Main(string[] args)
    {
        Robot robot = new();
        robot.Run();
    }
}
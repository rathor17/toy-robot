using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Helper;
using static ToyRobot.Enums.CommandEnum;
using static ToyRobot.Enums.DirectionEnum;

namespace ToyRobot
{
    public class ToyRobotSimulator
    {
        public ToyRobot _ToyRobot { get; set; }

        public ToyRobotSimulator(ToyRobot ToyRobot)
        {
            this._ToyRobot = ToyRobot;
        }

        public string ExecuteCommand(string command)
        {
            string result = string.Empty;
            try
            {
                Position position = null;
                command = command.ToUpper();
                Command resultCommand = GetValidCommandAndArguments(command, ref position);
                switch (resultCommand)
                {
                    case Command.PLACE:
                        _ToyRobot.Place(position.xAxisPosition.Value, position.yAxisPosition.Value, position.facing);
                        break;
                    case Command.MOVE:
                        _ToyRobot.Move();
                        break;
                    case Command.LEFT:
                        _ToyRobot.Left();
                        break;
                    case Command.RIGHT:
                        _ToyRobot.Right();
                        break;
                    case Command.REPORT:
                        result = _ToyRobot.Report();
                        break;
                    default:
                        break;

                }
            }
            catch (ToyRobotInvalidOperationException ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public Command GetValidCommandAndArguments(string command, ref Position position)
        {
            string remainingArg = string.Empty;
            int firstIndexOfSpace = command.IndexOf(' ');
            if (firstIndexOfSpace > 0)
            {
                remainingArg = command.Substring(firstIndexOfSpace + 1);
                command = command.Substring(0, firstIndexOfSpace);
            }
            if (Enum.TryParse(command, out Command result))
            {
                if (result == Enums.CommandEnum.Command.PLACE)
                {
                    if (!ValidatePlaceCommand(remainingArg, ref position))
                    {
                        throw new ToyRobotInvalidOperationException("Check the arguments", command);
                    }
                }
                return result;
            }
            throw new ToyRobotInvalidOperationException("Please check your command again");
        }

        public bool ValidatePlaceCommand(string placeCommand, ref Position position)
        {
            string[] xargs = placeCommand.Split(',');
            int _x, _y;
            if (xargs.Length != 3)
                return false;

            int.TryParse(xargs[0], out _x);
            int.TryParse(xargs[1], out _y);
            if (_x < 0 || _y < 0 || _x > 5 || _y > 5)
                return false;

            if (!Enum.TryParse(xargs[2], out DirectionFacing _facing))
                return false;

            position = new Position
            {
                xAxisPosition = _x,
                yAxisPosition = _y,
                facing = _facing
            };
            return true;
        }
    }
}

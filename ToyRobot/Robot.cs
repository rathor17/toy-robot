using ToyRobot.Helper;
using ToyRobot.Interfaces;
using static ToyRobot.Enums.DirectionEnum;

namespace ToyRobot
{
    public abstract class IsMovementAllowed : IRobot
    {
        public Position currentPosition;
        private const int SIZE = 5;

        public string Report()
        {
            CheckPlaced();
            return String.Format("{0},{1},{2}", currentPosition?.xAxisPosition.GetValueOrDefault(), currentPosition?.yAxisPosition.GetValueOrDefault(), currentPosition?.facing.ToString().ToUpper());
        }

        public void CheckMovementAllowed(int x, int y)
        {
            if (x < 0 || y < 0 || x > SIZE || y > SIZE)
            {
                throw new ToyRobotInvalidOperationException("Movement not allowed");
            }
        }

        public void CheckPlaced()
        {
            if (!(currentPosition.xAxisPosition.HasValue) || !(currentPosition.yAxisPosition.HasValue))
            {
                throw new ToyRobotInvalidOperationException("ToyRobot not placed on the board");
            }
        }

        public abstract void Place(int x, int y, DirectionFacing facing);
        public abstract void Move();
        public abstract void Left();
        public abstract void Right();
    }
}

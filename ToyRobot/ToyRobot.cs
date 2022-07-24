using ToyRobot.Helper;
using static ToyRobot.Enums.DirectionEnum;
using static ToyRobot.Enums.RotateEnum;

namespace ToyRobot
{
    public class ToyRobot : IsMovementAllowed
    {
        public ToyRobot()
        {
            base.currentPosition = new Position();
        }
        public override void Place(int x, int y, DirectionFacing facing)
        {
            CheckMovementAllowed(x, y);

            currentPosition.xAxisPosition = x;
            currentPosition.yAxisPosition = y;
            currentPosition.facing = facing;
        }

        public override void Move()
        {
            CheckPlaced();
            int newXAxisPosition = MoveAlongXAxis();
            int newYAxisPosition = MoveAlongYAxis();
            CheckMovementAllowed(newXAxisPosition, newYAxisPosition);
            currentPosition.xAxisPosition = newXAxisPosition;
            currentPosition.yAxisPosition = newYAxisPosition;
        }

        public override void Left()
        {
            Rotate(RotateDirection.Left);
        }

        public override void Right()
        {
            Rotate(RotateDirection.Right);
        }


        public int MoveAlongXAxis()
        {
            if (currentPosition.facing == DirectionFacing.EAST)
            {
                return currentPosition.xAxisPosition.Value + 1;
            }
            else
            {
                if (currentPosition.facing == DirectionFacing.WEST)
                {
                    return currentPosition.xAxisPosition.Value - 1;
                }
            }
            return currentPosition.xAxisPosition.Value;
        }

        public int MoveAlongYAxis()
        {
            if (currentPosition.facing == DirectionFacing.NORTH)
            {
                return currentPosition.yAxisPosition.Value + 1;
            }
            else
            {
                if (currentPosition.facing == DirectionFacing.SOUTH)
                {
                    return currentPosition.yAxisPosition.Value - 1;
                }
            }
            return currentPosition.yAxisPosition.Value;
        }

        public void Rotate(RotateDirection directionFacing)
        {
            CheckPlaced();
            var facingNo = (int)currentPosition.facing;
            facingNo += 1 * (directionFacing == RotateDirection.Right ? 1 : -1);
            if (facingNo == 5) facingNo = 1;
            if (facingNo == 0) facingNo = 4;
            currentPosition.facing = (DirectionFacing)facingNo;
        }
    }
}

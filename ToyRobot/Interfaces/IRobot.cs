using static ToyRobot.Enums.DirectionEnum;

namespace ToyRobot.Interfaces
{
    public interface IRobot
    {
        void Place(int x, int y, DirectionFacing facing);
        void Move();
        void Left();
        void Right();
        void CheckMovementAllowed(int x, int y);
        void CheckPlaced();
    }
}

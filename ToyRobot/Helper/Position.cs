using static ToyRobot.Enums.DirectionEnum;

namespace ToyRobot.Helper
{
    public class Position
    {
        public int? xAxisPosition { get; set; }
        public int? yAxisPosition { get; set; }
        public DirectionFacing facing { get; set; }
    }
}

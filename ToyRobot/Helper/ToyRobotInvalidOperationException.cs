namespace ToyRobot.Helper
{
    public class ToyRobotInvalidOperationException : Exception
    {
        public ToyRobotInvalidOperationException(string message)
            : base(string.Format("Exception: Message - {0}", message))
        {
        }

        public ToyRobotInvalidOperationException(string message, string action)
            : base(string.Format("Exception: Message - {0} Action:{1}", message, action))
        {
        }
    }
}

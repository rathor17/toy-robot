using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Helper;

namespace ToyRobot.Tests
{
    [TestClass]
    public class ToyRobotTests
    {
        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - ToyRobot not placed on the board")]
        public void ToyRobot_NotPlaced_CannotMove()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Move();
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - ToyRobot not placed on the board")]
        public void ToyRobot_NotPlaced_CannotTurnedLeft()
        {
            var turle = new ToyRobot();
            turle.Left();
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - ToyRobot not placed on the board")]
        public void ToyRobot_NotPlaced_CannotTurnedRight()
        {
            var turle = new ToyRobot();
            turle.Right();
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - ToyRobot not placed on the board")]
        public void ToyRobot_NotPlaced_CannotReportPosition()
        {
            var turle = new ToyRobot();
            turle.Report();
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - Check the arguments Action:PLACE")]
        public void ToyRobot_InValidPlaceArgument()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(0, -5, Enums.DirectionEnum.DirectionFacing.EAST);
        }

        [TestMethod]
        public void ToyRobot_PlacedAndReportsPosition()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(0, 3, Enums.DirectionEnum.DirectionFacing.EAST);
            var position = ToyRobot.Report();
            Assert.AreEqual("0,3,EAST", position);
        }

        [TestMethod]
        public void ToyRobot_Placed_CorrectDirection_Moved_ReportsCorrectPostion()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(0, 3, Enums.DirectionEnum.DirectionFacing.EAST);
            ToyRobot.Move();
            var position = ToyRobot.Report();
            Assert.AreEqual("1,3,EAST", position);
        }

        [TestMethod]
        [ExpectedException(typeof(ToyRobotInvalidOperationException), "Exception: Message - Movement not allowed")]
        public void ToyRobot_Placed_InCorrectDirection_Moved_ReportPostion()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(0, 0, Enums.DirectionEnum.DirectionFacing.SOUTH);
            ToyRobot.Move();
        }

        [TestMethod]
        public void ToyRobot_Placed_Moved_Rotated_ReportsCorrectPosition()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(1, 2, Enums.DirectionEnum.DirectionFacing.EAST);
            ToyRobot.Move();
            ToyRobot.Move();
            ToyRobot.Left();
            ToyRobot.Move();
            Assert.AreEqual("3,3,NORTH", ToyRobot.Report());
        }

        [TestMethod]
        public void ToyRobot_Placed_TurnedRight_Moved_ReportsCorrectPostion()
        {
            var ToyRobot = new ToyRobot();
            ToyRobot.Place(1, 2, Enums.DirectionEnum.DirectionFacing.NORTH);
            ToyRobot.Right();
            ToyRobot.Move();
            var postion = ToyRobot.Report();
            Assert.AreEqual("2,2,EAST", postion);
        }
    }
}

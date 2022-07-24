namespace ToyRobot.Tests
{
    [TestClass]
    public class ToyRobotSimulatorTests
    {
        [TestMethod]
        public void ToyRobotSimulator_Initialised_HasToyRobot()
        {
            var ToyRobotSimulator = new ToyRobotSimulator(new ToyRobot());
            Assert.IsNotNull(ToyRobotSimulator._ToyRobot);
        }

        [TestMethod]
        //ToyRobotSimulator
        public void ToyRobotSimulator_Empty_Command()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("");
            Assert.AreEqual("Exception: Message - Please check your command again", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Invalid_Command()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("SHAZAM");
            Assert.AreEqual("Exception: Message - Please check your command again", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_NotPlaced_CannotBeMoved()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("MOVE");
            Assert.AreEqual("Exception: Message - ToyRobot not placed on the board", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_NotPlaced_CannotBeTurnedLeft()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("LEFT");
            Assert.AreEqual("Exception: Message - ToyRobot not placed on the board", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_NotPlaced_CannotBeTurnedRight()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("RIGHT");
            Assert.AreEqual("Exception: Message - ToyRobot not placed on the board", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_NotPlaced_CannotReportPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("Exception: Message - ToyRobot not placed on the board", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Invalid_Place_Command()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("PLACE");
            Assert.AreEqual("Exception: Message - Check the arguments Action:PLACE", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Invalid_Place_Command_Arguments()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            var result = sim.ExecuteCommand("PLACE 0,-5,NORTH");
            Assert.AreEqual("Exception: Message - Check the arguments Action:PLACE", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_ReportPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 0,1,EAST");
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("0,1,EAST", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_InWrongDirection_CannotBeMoved()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 5,5,EAST");
            var result = sim.ExecuteCommand("MOVE");
            Assert.AreEqual("Exception: Message - Movement not allowed", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_In_CorrectDirection_Moved_ReportsPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 0,5,EAST");
            sim.ExecuteCommand("MOVE");
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("1,5,EAST", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_Turned_Right_ReportsPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 0,1,NORTH");
            sim.ExecuteCommand("RIGHT");
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("0,1,EAST", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_Turned_Left_ReportsPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 0,1,NORTH");
            sim.ExecuteCommand("LEFT");
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("0,1,WEST", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_And_Moved_Off_Table_CannotBeMoved()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 5,5,NORTH");
            var result = sim.ExecuteCommand("MOVE");
            Assert.AreEqual("Exception: Message - Movement not allowed", result);
        }

        [TestMethod]
        public void ToyRobotSimulator_Placed_Moved_Turned_ReportsPosition()
        {
            var sim = new ToyRobotSimulator(new ToyRobot());
            sim.ExecuteCommand("PLACE 3,2,NORTH");
            sim.ExecuteCommand("MOVE");
            sim.ExecuteCommand("RIGHT");
            sim.ExecuteCommand("MOVE");
            sim.ExecuteCommand("LEFT");
            sim.ExecuteCommand("MOVE");
            var result = sim.ExecuteCommand("REPORT");
            Assert.AreEqual("4,4,NORTH", result);
        }
    }
}
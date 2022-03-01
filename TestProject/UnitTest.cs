using Mars_Rover;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Valid test case
        [Test]
        public void Test1()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(1, 2, 'N');
            rover.Set_MovementSeries("LMLMLMLMM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("1 3 N", result);
        }

        //Valid test case
        [Test]
        public void Test2()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(3, 3, 'E');
            rover.Set_MovementSeries("MMRMMRMRRM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("5 1 E", result);
        }

        //It is the scenario that occurs when the command to move out of the plateau is given.
        [Test]
        public void Test3()
        {
            string[] upperRightCoordinates = { "2", "2" };
            Rover rover = new Rover(3, 3, 'E');
            rover.Set_MovementSeries("MMRMMRMRRM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreNotEqual("5 1 E", result);
        }

        //This is the scenario that happens when the missing upper-right coordinate is given.
        [Test]
        public void Test4()
        {
            string[] upperRightCoordinates = { "2" };
            Rover rover = new Rover(1, 2, 'E');
            rover.Set_MovementSeries("MMRMMRMRRMM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("Plateau coordinates were entered incorrectly.", result);
        }

        //This is the scenario that will occur when movement commands are given in lower case.
        [Test]
        public void Test5()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(1, 2, 'N');
            rover.Set_MovementSeries("LMLmLmLMM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("1 3 N", result);
        }

        //This is the scenario that will happen when the list of moves where the rover will explore the plateau is not sent.
        [Test]
        public void Test6()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(1, 2, 'N');
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("The list of moves that the Rover will explore the plateau has not been sent.", result);
        }

        //This is the scenario that happens when the list of moves that Rover will explore the plateau is sent incorrectly.
        [Test]
        public void Test7()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(1, 2, 'N');
            rover.Set_MovementSeries("LMLMLMLZZ");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("The list of moves for which Rover will explore the plateau has been sent incorrectly.", result);
        }

        //This is the scenario that will occur when the rover's direction information is sent incorrectly.
        [Test]
        public void Test8()
        {
            string[] upperRightCoordinates = { "5", "5" };
            Rover rover = new Rover(1, 2, 'A');
            rover.Set_MovementSeries("LMLMLMLMM");
            var result = rover.StartRover(upperRightCoordinates);

            Assert.AreEqual("The rover's direction information is incorrect.", result);
        }
    }
}
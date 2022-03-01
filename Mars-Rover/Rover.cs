using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Rover
    {
        public Rover(int x, int y, char direction)
        {
            Direction = direction;
            X_Coordinate = x;
            Y_Coordinate = y;
        }

        //It is the variable that holds the direction of the rover.
        private char Direction { get; set; }

        //It is the variable that holds the x coordinate value of the rover.
        private int X_Coordinate { get; set; }

        //It is the variable that holds the y coordinate value of the rover.
        private int Y_Coordinate { get; set; }

        //Variable to hold the movements of the rover.
        private string MovementSeries { get; set; }

        //Function to set the rover's movements
        public void Set_MovementSeries(string movementSeries)
        {
            MovementSeries = movementSeries.ToUpper();
        }

        //It is the function that returns the x coordinate value of the rover.
        public int Get_X_Coordinate()
        {
            return X_Coordinate;
        }

        //It is the function that returns the y coordinate value of the rover.
        public int Get_Y_Coordinate()
        {
            return Y_Coordinate;
        }

        //It is the function that returns the rover's direction information.
        public char Get_Direction()
        {
            return Direction;
        }

        //It is the function that makes the rover turn left.
        public string Left ()
        {
            if (Direction == 'E')
                return "N";
            else if (Direction == 'N')
                return "W";
            else if (Direction == 'W')
                return "S";
            else if (Direction == 'S')
                return "E";
            else
                return "The rover's direction information is incorrect.";
        }

        //It is the function that makes the rover turn right.
        public string Right()
        {
            if (Direction == 'E')
               return "S";
            else if (Direction == 'N')
                return "E";
            else if (Direction == 'W')
                return "N";
            else if (Direction == 'S')
                return "W";
            else
                return "The rover's direction information is incorrect.";
        }

        //It is the function that makes the rover go forward 1 grid.
        public void Move(int plato_X_Coordinate, int plato_Y_Coordinate)
        {
            if (Direction == 'E')
                //When the rover moves, it is checked whether it stays within the plateau.
                if (plato_X_Coordinate > X_Coordinate)
                    X_Coordinate++;
                else
                    Console.WriteLine("Invalid move! Rover has come off the plateau.");
            else if (Direction == 'N')
                //When the rover moves, it is checked whether it stays within the plateau.
                if (plato_Y_Coordinate > Y_Coordinate)
                    Y_Coordinate++;
                else
                    Console.WriteLine("Invalid move! Rover has come off the plateau.");
            else if (Direction == 'W')
                //When the rover moves, it is checked whether it stays within the plateau.
                if (X_Coordinate > 0)
                    X_Coordinate--;
                else
                    Console.WriteLine("Invalid move! Rover has come off the plateau.");
            else if (Direction == 'S')
                //When the rover moves, it is checked whether it stays within the plateau.
                if (Y_Coordinate > 0)
                    Y_Coordinate--;
                else
                    Console.WriteLine("Invalid move! Rover has come off the plateau.");
            else
                Console.WriteLine("The rover's direction information is incorrect.");
        }

        public string StartRover(string[] upperRightCoordinates)
        {
            if (upperRightCoordinates.Length != 2)
                return "Plateau coordinates were entered incorrectly.";
            //Checking the rover's x-coordinate.
            else if (string.IsNullOrEmpty(X_Coordinate.ToString()))
                return "The rover's x-coordinate is not specified.";
            //Checking the rover's y-coordinate.
            else if (string.IsNullOrEmpty(Y_Coordinate.ToString()))
                return "The rover's y-coordinate is not specified.";
            //The rover's direction is being checked.
            else if (string.IsNullOrEmpty(Direction.ToString()))
                return "The direction of the rover is not specified.";
            //The input value that specifies the movements to be made by the rover is checked.
            else if (string.IsNullOrEmpty(MovementSeries))
                return "The list of moves that the Rover will explore the plateau has not been sent.";
            else
            {
                //The letters in the input value indicating the movements that the rover will do are looked at.
                for (int y = 0; y < MovementSeries.Length; y++)
                {
                    //If the letter read is L, the "Left" function is called to make the rover turn left.
                    if (MovementSeries[y] == 'L')
                    {
                        var result = Left();
                        if (result != "The rover's direction information is incorrect.")
                            Direction = Convert.ToChar(result);
                        else
                            return result;
                    }
                    //If the letter read is L, the "Right" function is called to make the rover turn left.
                    else if (MovementSeries[y] == 'R')
                    {
                        var result = Right();
                        if (result != "The rover's direction information is incorrect.")
                            Direction = Convert.ToChar(result);
                        else
                            return result;
                    }                    
                    //If the letter read is M, the "Move" function is called to move the rover 1 grid forward.
                    else if (MovementSeries[y] == 'M')
                        Move(Convert.ToInt32(upperRightCoordinates[0]), Convert.ToInt32(upperRightCoordinates[1]));
                    //If the letter read is not L, R or M, an incorrect input message is returned.
                    else
                        return "The list of moves for which Rover will explore the plateau has been sent incorrectly.";
                }

                //The rover's output is being returned.
                return Get_X_Coordinate() + " " + Get_Y_Coordinate() + " " + Get_Direction();
            }
        }
    }
}

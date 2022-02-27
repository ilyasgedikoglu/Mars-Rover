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
        public void Left ()
        {
            if (Direction == 'E')
                Direction = 'N';
            else if (Direction == 'N')
                Direction = 'W';
            else if (Direction == 'W')
                Direction = 'S';
            else
                Direction = 'E';           
        }

        //It is the function that makes the rover turn right.
        public void Right()
        {
            if (Direction == 'E')
                Direction = 'S';
            else if (Direction == 'N')
                Direction = 'E';
            else if (Direction == 'W')
                Direction = 'N';
            else
                Direction = 'W';
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
            else
            //When the rover moves, it is checked whether it stays within the plateau.
                if (Y_Coordinate > 0)
                    Y_Coordinate--;
                else
                    Console.WriteLine("Invalid move! Rover has come off the plateau.");
        }
    }
}

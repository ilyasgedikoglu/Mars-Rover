using System;
using System.Collections.Generic;

namespace Mars_Rover
{
    public class Program
    {
        /*
         * İLYAS GEDİKOĞLU - MARS ROVER PROJECT
         */

        /*
         * After entering the input values, press the enter key to see the output value.
         */

        //It is the list variable that will hold the input values.
        static List<Rover> inputList = new List<Rover>();

        static void Main(string[] args)
        {
            //It is the variable that will hold the upper right coordinate value.
            string[] upperRightCoordinates = new string[3];

            //We get the upper right coordinate value from the user.
            var upperRightCoordinate = Console.ReadLine();
            if (!string.IsNullOrEmpty(upperRightCoordinate))
            {
                //If the value is not empty, we divide the value according to the spaces and assign it to our variable.
                upperRightCoordinates = upperRightCoordinate.Split(' ');

                if (upperRightCoordinates.Length == 2)
                {
                    //I created an infinite loop to enter an input value until the enter key is pressed.
                    while (true)
                    {
                        //We're getting the rover's coordinates.
                        var input = Console.ReadLine();

                        //If the entered value is empty, the loop is exited.
                        if (string.IsNullOrEmpty(input))
                            break;
                        else
                        {
                            //The input value specifying the coordinate and direction is divided by looking at the spaces.
                            var input1List = input.Split(' ');

                            //Checking the accuracy of the input value.
                            if (input1List.Length < 3 || input1List.Length > 3)
                                Console.WriteLine("Rover's location information is missing or entered incorrectly.");
                            else
                            {
                                //Creating the Rover object. The first parameter is the x coordinate, the second parameter is the y coordinate, and the third parameter is the direction.
                                Rover rover = new Rover(Convert.ToInt32(input1List[0]), Convert.ToInt32(input1List[1]), Convert.ToChar(input1List[2].ToUpper()));

                                //We get the movements that the rover will do.
                                var input2 = Console.ReadLine();

                                //The input value that specifies the movements to be made by the rover is checked.
                                if (string.IsNullOrEmpty(input2))
                                    Console.WriteLine("The list of moves that the Rover will explore the plateau has not been sent.");
                                else
                                {
                                    rover.Set_MovementSeries(input2);

                                    //If the entered value is not empty, it is added to the input list.
                                    inputList.Add(rover);
                                }
                            }
                        }
                    }

                    //This function is called to start the navigation when the input entries are finished.
                    foreach (var item in inputList)
                    {
                        var result = item.StartRover(upperRightCoordinates);
                        //The rover's output is printed on the screen.
                        Console.WriteLine(result);
                    }                      
                }
                else
                    Console.WriteLine("Plateau coordinates were entered incorrectly.");
            }
        }
    }
}
